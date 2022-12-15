# If and swtich to switch expression

Microsoft docs switch expression - [pattern matching expressions using the switch keyword](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/switch-expression)

From

```csharp
public static string TimeOfDay()
{
    var result = "";
    if (Now.Hour < 12)
    {
        result = "Good Morning";
    }
    else if (Now.Hour < 16)
    {
        result = "Good Afternoon";
    }
    else if (Now.Hour < 20)
    {
        result = "Good Evening";
    }
    else
    {
        result = "Good Night";
    }

    return result;
}
```

To

```csharp
public static string TimeOfDay() =>
    Now.Hour switch
    {
        <= 12 => "Good Morning",
        <= 16 => "Good Afternoon",
        <= 20 => "Good Evening",
        _ => "Good Night"
    };
```

![Stop](assets/stop.png)

Although `switch expression` are new to many

- Only use them when your team mates understand them
- Ask the question, can I still debug properly
- Keep it simple, unlike the following
 
:roll_eyes: cool but hard to maintain

```csharp
public static string FormatElapsed(this TimeSpan span) => span.Days switch
{
    > 0 => $"{span.Days} days, {span.Hours} hours, {span.Minutes} minutes, {span.Seconds} seconds",
    _ => span.Hours switch
    {
        > 0 => $"{span.Hours} hours, {span.Minutes} minutes, {span.Seconds} seconds",
        _ => span.Minutes switch
        {
            > 0 => $"{span.Minutes} minutes, {span.Seconds} seconds",
            _ => span.Seconds switch
            {
                > 0 => $"{span.Seconds} seconds",
                _ => ""
            }
        }
    }
};
```


:smile: Easier to read and debug

```csharp
public static string FormatElapsed(this TimeSpan span)
{
    if (span.Days > 0)
    {
        return $"{span.Days} days, {span.Hours} hours, {span.Minutes} minutes, {span.Seconds} seconds";
    }

    switch (span)
    {
        case { Hours: > 0 }:
            return $"{span.Hours} hours, {span.Minutes} minutes, {span.Seconds} seconds";
        default:
            switch (span)
            {
                case { Minutes: > 0 }:
                    return $"{span.Minutes} minutes, {span.Seconds} seconds";
                default:
                    switch (span.Seconds)
                    {
                        case > 0:
                            return $"{span.Seconds} seconds";
                        default:
                            return "";
                    }
            }
    }
}
```
