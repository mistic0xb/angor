using System.Diagnostics;
using Avalonia;
using Avalonia.Data.Converters;
using Avalonia.Svg;
using Humanizer;
using Projektanker.Icons.Avalonia;
using Zafiro.Mixins;
using Zafiro.UI.Navigation.Sections;

namespace AngorApp.UI.Controls;

public static class AngorConverters
{
    public static readonly FuncValueConverter<string, object> StringToIcon = new(str =>
    {
        if (str is null)
        {
            return AvaloniaProperty.UnsetValue;
        }

        var prefix = str.Split(":");
        if (prefix[0] == "svg")
        {
            return new Avalonia.Svg.Svg(new Uri("avares://AngorApp"))
            {
                Path = prefix[1]
            };
        }

        return new Icon
        {
            Value = str
        };
    });

    public static readonly FuncValueConverter<ISection, bool> IsActivatable = new(sectionBase => sectionBase is not ISectionSeparator);

    public static readonly FuncValueConverter<bool, Dock> IsPrimaryToDock = new(isPrimary => isPrimary ? Dock.Top : Dock.Bottom);
    
    public static readonly FuncValueConverter<DateTimeOffset, string> TimeLeft = new(offset =>
    {
        return offset.Humanize(dateToCompareAgainst: DateTimeOffset.Now);
    });
    
    public static readonly FuncValueConverter<TimeSpan, string> HumanizeTimeSpan = new(offset => offset.Humanize());
    
    public static readonly FuncValueConverter<DateTimeOffset, string> HumanizeDateTimeOffset = new(offset =>
    {
        if (DateTimeOffset.Now.Date - offset < 2.Days())
        {
            return offset.Humanize();
        }

        return offset.ToString("d");
    });
    
    public static readonly FuncValueConverter<DateTime?, string> HumanizeDateTime = new(offset =>
    {
        if (offset == null)
        {
            return null;
        }
        
        if (DateTime.Now.Date - offset < 2.Days())
        {
            return offset.Humanize();
        }

        return offset.Value.ToString("d");
    });

    public static readonly FuncValueConverter<bool, double> BoolToOpacity = new(b => b ? 1 : 0);

    public static FuncValueConverter<string, string> HubProfile = new((value) =>
    {
        return "https://hub.angor.io/profile/" + value;
    });

    public static string BigBtcFormat = "{0} BTC";
    public static string AmountBtcFormat = "0.0000 0000 BTC";
    public static string Sats = "{0} sats";

    public static FuncValueConverter<string, SvgImage> StringToQRCode { get; } = new(s =>
    {
        Debug.Assert(s != null, nameof(s) + " != null");
        return QRGenerator.SvgImageFrom(s);
    });

    public static FuncValueConverter<long, string> SatsToBtcString { get; } = new(satoshis =>
    {
        var btc = satoshis / (decimal)10000_0000;
        return $"{btc:0.0000 0000}" + " BTC";
    });

    public static FuncValueConverter<IEnumerable<string>, string> JoinWithSpaces { get; } = new(enumerable =>
    {
        if (enumerable != null)
        {
            return enumerable.JoinWith(" ");
        }

        return "";
    });

    public static FuncValueConverter<long, decimal> SatsToBtc { get; } = new(satoshis =>
    {
        var btc = satoshis / (decimal)1_0000_0000;
        return btc;
    });
}