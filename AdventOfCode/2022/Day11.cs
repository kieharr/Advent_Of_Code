using System.Text.RegularExpressions;
using MoreLinq;

namespace AdventOfCode._2022;

public class Day11: Solution
{
    public override string Part1(IEnumerable<string> input)
    {
        var monkeys = BuildMonkeys(input);
        PlayRounds(monkeys, 20);
        return GetResult(monkeys).ToString();
    }
    
    public override string Part2(IEnumerable<string> input)
    {
        var monkeys = BuildMonkeys(input, true);
        PlayRounds(monkeys, 10_000);
        return GetResult(monkeys).ToString();
    }
    
    private readonly record struct Item(long WorryLevel)
    {
        public readonly record struct ThrowItem(Item Item, int MonkeyNumber);
        public Item AdjustWorry(Func<long, long> func) => new (func(WorryLevel));
        public ThrowItem Throw(Func<Item, ThrowItem> func) => func(this);
    }

    private class Monkey
    {
        private readonly Func<long, long> _decreaseWorry;
        private readonly Func<long, long> _increaseWorry;
        private readonly Func<Item, Item.ThrowItem> _throwItem;
        private readonly Queue<Item> _items;
        
        public long Counter { get; private set; }

        public Monkey(MonkeySettings settings)
        {
            _decreaseWorry = settings.DecreaseWorry;
            _increaseWorry = settings.IncreaseWorry;
            _throwItem = settings.ThrowItem;
            _items = new Queue<Item>(settings.Items);
        }
        
        public void Catch(Item item)
        {
            _items.Enqueue(item);
        }

        public IEnumerable<Item.ThrowItem> GetThrows()
        {
            Counter += _items.Count;
            while (_items.Count > 0)
            {
                yield return _items.Dequeue()
                    .AdjustWorry(_increaseWorry)
                    .AdjustWorry(_decreaseWorry)
                    .Throw(_throwItem);
            }
        }
    }
    
    private class MonkeySettings
    {
        private static readonly Regex MonkeyRegex = new (@$".+
(?>[^\d]+(?'{nameof(Items)}'\d+))+
[^\d=]+=\s(?'{nameof(IncreaseWorry)}'.*)
[^\d]+(?'{nameof(Divisor)}'\d+)
[^\d]+(?'{true}'\d+)
[^\d]+(?'{false}'\d+)");

        public int Divisor { get; }
        public IEnumerable<Item> Items { get; }
        public Func<Item, Item.ThrowItem> ThrowItem { get; }
        public Func<long, long> IncreaseWorry { get; }
        public Func<long, long> DecreaseWorry { get; private set; }

        public MonkeySettings(string input)
        {
            var matches = MonkeyRegex.Match(input);
            Divisor = matches.GetFirstInGroup<int>(nameof(Divisor));
            Items = matches.GetAllInGroup<long>(nameof(Items)).Select(x => new Item(x));
            ThrowItem = BuildThrowItemFunc(
                Divisor, 
                matches.GetFirstInGroup<int>(true.ToString()), 
                matches.GetFirstInGroup<int>(false.ToString())
            );
            IncreaseWorry = BuildIncreaseWorryFunction(matches.GetFirstInGroup(nameof(IncreaseWorry)));
            DecreaseWorry = x => x / 3;
        }

        public void SetModuloFunc(int commonDivisor)
        {
            DecreaseWorry = x => x % commonDivisor;
        }

        private static Func<Item, Item.ThrowItem> BuildThrowItemFunc(int divisor, int monkeyIfTrue, int monkeyIfFalse)
            => x => new Item.ThrowItem(x, x.WorryLevel % divisor == 0 ? monkeyIfTrue : monkeyIfFalse);

        private static Func<long, long> BuildIncreaseWorryFunction(string rhs) =>
            rhs switch
            {
                "old + old" => x => x + x,
                "old * old" => x => x * x,
                {} when rhs.StartsWith("old +") => x => x + int.Parse(rhs[6..]),
                {} when rhs.StartsWith("old *") => x => x * int.Parse(rhs[6..]),
                _ => throw new ArgumentOutOfRangeException(nameof(rhs), rhs, null)
            };
    }

    private static List<Monkey> BuildMonkeys(IEnumerable<string> input, bool withModulo = false)
    {
        var monkeySettings = input.JoinLines()
            .Split($"{Environment.NewLine}{Environment.NewLine}")
            .Select(x => new MonkeySettings(x)).ToList();

        if (withModulo)
        {
            var bigModulo = monkeySettings.Select(x => x.Divisor).Distinct()
                .Aggregate(1, (i, divisor) => i * divisor);
            monkeySettings.ForEach(x => x.SetModuloFunc(bigModulo));
        }
        return monkeySettings.Select(x => new Monkey(x)).ToList();
    }

    private static void PlayRounds(List<Monkey> monkeys, int numberOfRounds)
    {
        Enumerable.Range(1, numberOfRounds).ForEach(_ =>
        {
            monkeys.SelectMany(monkey => monkey.GetThrows()).ForEach(x =>
            {
                monkeys[x.MonkeyNumber].Catch(x.Item);
            });
        });
    }
    
    private static long GetResult(IEnumerable<Monkey> monkeys) =>
        monkeys.OrderByDescending(x => x.Counter).Take(2)
            .Aggregate(1L, (i, monkey) => i * monkey.Counter);
}