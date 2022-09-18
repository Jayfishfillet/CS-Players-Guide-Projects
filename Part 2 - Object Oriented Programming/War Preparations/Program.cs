Console.Title = "War Preparations";

Sword ironSword = new Sword(SwordMaterial.Iron, Gemstone.None, 50 , 7);
Sword rubySteelSword = ironSword with { stone = Gemstone.Ruby, material = SwordMaterial.Steel};
Sword UltimateSword = ironSword with { stone = Gemstone.Bitstone, material = SwordMaterial.Binarium};

Console.WriteLine($"{nameof(ironSword)}: {ironSword.ToString()}\n");
Console.WriteLine($"{nameof(rubySteelSword)}: {rubySteelSword.ToString()}\n");
Console.WriteLine($"{nameof(UltimateSword)}: {UltimateSword.ToString()}");

internal record Sword(SwordMaterial material, Gemstone stone, float length, float crossguardWidth)
{
    public override string ToString()
    {
        return $"a {length}inch {material} blade with a {crossguardWidth}inch crossguard. Stone type: {stone}";
    }
}

internal enum SwordMaterial { Wood, Bronze, Iron, Steel, Binarium }
internal enum Gemstone { Emerald, Amber, Sapphire, Diamond, Ruby, Bitstone, None}