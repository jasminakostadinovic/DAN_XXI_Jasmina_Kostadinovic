namespace Dan_XXI_Zadatak.Models.Money
{
    class RSDMoney
    {
        public RSDMoney(int numberOfItems, int valueOfItem)
        {
            NumberOfItems = numberOfItems;
            ValueOfItem = valueOfItem;
        }

        public int NumberOfItems { get; protected set; }
        public int ValueOfItem { get; protected set; }
        public MoneyType MoneyType
        {

            get
            {
                if(ValueOfItem < 10)
                {
                    return MoneyType.Coin;
                }

                return MoneyType.Bill;
            }
        }

        public override string ToString()
        {
            return string.Format($"{NumberOfItems} {MoneyType.ToString()}s {ValueOfItem} RSD");
        }
    }
}
