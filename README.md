# Terminal calculator

Simple calculator for evaluation of the following expressions:

* `add(1,2)`
* `mult(add(2,2),div(9,3))`
* `add(add(add(div(1,1),1),1),add(1,mult(1,1)))`

## Implementation

Implementation idea was borrowed from [Shunting-yard algorithm](https://en.wikipedia.org/wiki/Shunting-yard_algorithm) with some modifications. Please follow the example for more details.

`mult(add(2,2),div(9,3))`

1. Represent input string as array of tokens ([Tokenizer](./Calculator/Tokenizer.cs)). Where token has the following structure:

``` csharp
public class Token
{
    ..
    public TokenType Type { get; set; }

    public long? Value { get; set; }
    ..
}

public enum TokenType
{
    ..
    Number,
    Add,
    Mult,
    Div,
    ..
}
```

2. Iterate through the list of tokens and process them using stack ([TerminalCalculator](./Calculator/TerminalCalculator.cs)). Example:

**Step 1:**

``` csharp
// items in stack
'mult'
'add'
'2'
'2'
```

**Step 2:**

``` csharp
// items in stack
'mult'
'4'
'div'
'9'
'3'
```

**Step 3:**

``` csharp
// items in stack
'mult'
'4'
'3'
```

**Step 4:**

``` csharp
// items in stack
'12'
```

**Step 5:**

Return stack top element.
