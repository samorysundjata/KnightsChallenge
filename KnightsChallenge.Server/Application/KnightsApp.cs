using KnightsChallenge.Server.Entities;

namespace KnightsChallenge.Server.Application
{
    public class KnightsApp : IKnightsApp
    {
        public int CalculateAttack(Knight knight)
        {
            int keyAttrValue = GetAttributeValue(knight, knight.KeyAttribute);
            int weaponMod = knight.Weapons.FirstOrDefault(w => w.Equipped)?.Mod ?? 0;
            return 10 + Mod(keyAttrValue) + weaponMod;
        }

        public int CalculateExp(DateTime birthday)
        {
            int age = (int)((DateTime.Now - birthday).TotalDays / 365);
            if (age < 7) return 0;
            return (int)Math.Floor((age - 7) * Math.Pow(22, 1.45));
        }

        private int GetAttributeValue(Knight knight, string attribute)
        {
            switch (attribute.ToLower())
            {
                case "strength":
                    return knight.Attributes.Strength;
                case "dexterity":
                    return knight.Attributes.Dexterity;
                case "constitution":
                    return knight.Attributes.Constitution;
                case "intelligence":
                    return knight.Attributes.Intelligence;
                case "wisdom":
                    return knight.Attributes.Wisdom;
                case "charisma":
                    return knight.Attributes.Charisma;
                default:
                    throw new ArgumentException("Atributo inválido");
            }
        }

        private int Mod(int value)
        {
            if (value >= 0 && value <= 8) return -2;
            if (value >= 9 && value <= 10) return -1;
            if (value >= 11 && value <= 12) return 0;
            if (value >= 13 && value <= 15) return 1;
            if (value >= 16 && value <= 18) return 2;
            if (value >= 19 && value <= 20) return 3;
            return 0;
        }
    }
}
