using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item",menuName ="Inventory/Consumables")]
public class Consumables : Items
{
    public enum TypeOfConsumables { PhoenixKit,ShieldBattery,Medkit,ShieldCell,Syringe};
    public TypeOfConsumables typeofconsumables;
    public int Maxamount;
    public int timetouse;
    public int amountofheal;
    public int amountofshield;

   
}
