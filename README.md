# prarithmetic
prarithmetic is a Logic World mod that was originally supposed to add a lot of math based gates to the game, but it quickly became a mod of whatever i didnt want to build ingame.

# Components
## Adder4
Takes 2 4 bit numbers and a carry and returns a 4 bit sum and a carry

## ASCIIDecoder
Takes in the ASCII code for a character from A-Z or 0-9 and will display the given character.

## ByteDLatch
Works the same as the vanilla D latch, but stores 1 byte in half the space. The top input is the signal.

## Concatenator
Each input group (A0-3, B0-3, C0-3) takes in a binary number from 0-9 and will return the binary value of the three numbers concatenated. <br>
Ex: 0010 (2), 0101 (5), 0101 (5) will become 11111111 (255)

```
        Y0 Y1 Y2 Y3 Y4 Y5 Y6 Y7
        +  +  +  +  +  +  +  +
|------------------------------------|
|            Concatenator            |
|------------------------------------|
  |  |  |  |  |  |  |  |  |  |  |  |
  A0 A1 A2 A3 B0 B1 B2 B3 C0 C1 C2 C3
```

## Equal
Will output true if the top row of inputs matches the bottom row of inputs

## Multiplier4
Not implemented Yet.