using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Converters : System.Web.UI.Page
{
    net.webservicex.www.ConvertTemperature convTemp = new net.webservicex.www.ConvertTemperature();
    net.webservicex.www.ConvertSpeeds convSpeed = new net.webservicex.www.ConvertSpeeds();
    net.webservicex.www.ConvertWeights convWeight = new net.webservicex.www.ConvertWeights();
    net.webservicex.www.ComputerUnit convComp = new net.webservicex.www.ComputerUnit();

    protected void Page_Load(object sender, EventArgs e)
    {
        List<string> temperatureMetrics = new List<string> { "-Select-", "Celsius" , "Fahrenheit", "Rankine", "Reaumur", "kelvin" };
        List<string> speedMetrics = new List<string> { "-Select-", "centimeters per second", "meters per second", "feet per second", "feet per minute",
               "miles per hour", "kilometers per hour", "furlongs per minute", "knots", "Mach" };
        List<string> weightMetrics = new List<string> { "-Select-", "Grains", "Scruples", "Carats", "Grams", "Pennyweight", "Dram Avoir", "Dram Apoth", "Ounces Avoir",
                "Ounces Troy Apoth", "Poundals", "Pounds Troy", "Pounds Avoir", "Kilograms", "Stones", "Quarter US",
                "Slugs", "weight 100 UScwt", "Short Tons", "Metric Tons Tonne", "Long Tons"};

        List<string> computerMetrics = new List<string> { "-Select-", "Bit", "Byte", "Kilobyte", "Gigabyte", "Terabyte", "Petabyte" };

        if (IsPostBack == false)
        {
            // Temperature
            foreach (string s in temperatureMetrics)
            {
                dropDownListTempFrom.Items.Add(s);
                dropDownListTempTo.Items.Add(s);
            }
         
            // Speed
            foreach (string s in speedMetrics)
            {
                dropDownListSpeedFrom.Items.Add(s);
                dropDownListSpeedTo.Items.Add(s);
            }
       
            // Weight
            foreach (string s in weightMetrics)
            {
                dropDownListWeightFrom.Items.Add(s);
                dropDownListWeightTo.Items.Add(s);
            }

            // Computer
            foreach (string s in computerMetrics)
            {
                dropDownListComputerFrom.Items.Add(s);
                dropDownListComputerTo.Items.Add(s);
            }

        } // if
    }

    /// <summary>
    /// Μέθοδος που καλείται για μετατροπή θερμοκρασιών
    /// </summary>
    protected void TemperatureConverter(object sender, EventArgs e)
    {
        net.webservicex.www.TemperatureUnit fromDegree = encodeDegree(dropDownListTempFrom); ;
        net.webservicex.www.TemperatureUnit toDegree = encodeDegree(dropDownListTempTo);

        if (textBoxTemperatureInsert.Text != "")
        {
            double temp = Convert.ToDouble(textBoxTemperatureInsert.Text);

            double newTemp = convTemp.ConvertTemp(temp, fromDegree, toDegree);

            textBoxResult.Text = newTemp.ToString();
            textBoxResult.Visible = true;
        }
    }

    /// <summary>
    /// Μέθοδος που καλείται για μετατροπή ταχυτήτων.
    /// </summary>
    protected void SpeedConverter(object sender, EventArgs e)
    {
        net.webservicex.www.SpeedUnit speedFrom = encodeSpeed(dropDownListSpeedFrom);
        net.webservicex.www.SpeedUnit speedTo = encodeSpeed(dropDownListSpeedTo);

        if (textBoxSpeedInsert.Text != "")
        {
            double speed = Convert.ToDouble(textBoxSpeedInsert.Text);

            double newSpeed = convSpeed.ConvertSpeed(speed, speedFrom, speedTo);

            textBoxSpeedResult.Text = newSpeed.ToString();
            textBoxSpeedResult.Visible = true;
            
        }
    }

    /// <summary>
    /// Μέθοδος που καλείται για την μετατροπή βαρών.
    /// </summary>
    protected void WeightConverter(object sender, EventArgs e)
    {
        net.webservicex.www.WeightUnit weightFrom = encodeWeight(dropDownListWeightFrom);
        net.webservicex.www.WeightUnit weightTo = encodeWeight(dropDownListWeightTo);

        if (textBoxWeightInsert.Text != "")
        {
            double weight = Convert.ToDouble(textBoxWeightInsert.Text);

            double newWeight = convWeight.ConvertWeight(weight, weightFrom, weightTo);

            textBoxWeightResult.Text = newWeight.ToString();
            textBoxWeightResult.Visible = true;
        }
    }

    /// <summary>
    /// Μέθοδος που καλείται για μετατροπή μονάδων χώρου αποθήκευσης.
    /// </summary>
    protected void ComputerUnitConverter(object sender, EventArgs e)
    {
        net.webservicex.www.Computers sizeFrom = encodeComputer(dropDownListComputerFrom);
        net.webservicex.www.Computers sizeTo = encodeComputer(dropDownListComputerTo);

        if (textBoxComputerInsert.Text != "")
        {
            double size = Convert.ToDouble(textBoxComputerInsert.Text);

            double newSize = convComp.ChangeComputerUnit(size, sizeFrom, sizeTo);

            textBoxComputerResult.Text = newSize.ToString();
            textBoxComputerResult.Visible = true;
        }

    }

    /// <summary>
    /// Μέθοδος που παίρνει την επιλογή του χρήστη και την κωδικοποιεί για να μπορεί να κληθεί η υπηρεσία
    /// </summary>
    /// <param name="d"> dropdownList από όπου βλέπει την επιλογή </param>
    /// <returns> κωδικοποιημένη σωστά επιλογή </returns>
    private net.webservicex.www.TemperatureUnit encodeDegree(DropDownList d)
    {
        net.webservicex.www.TemperatureUnit Degree = net.webservicex.www.TemperatureUnit.degreeCelsius;

        switch (d.SelectedIndex)
        {
            case 1:
                Degree = net.webservicex.www.TemperatureUnit.degreeCelsius;
                break;
            case 2:
                Degree = net.webservicex.www.TemperatureUnit.degreeFahrenheit;
                break;
            case 3:
                Degree = net.webservicex.www.TemperatureUnit.degreeRankine;
                break;
            case 4:
                Degree = net.webservicex.www.TemperatureUnit.degreeReaumur;
                break;
            case 5:
                Degree = net.webservicex.www.TemperatureUnit.kelvin;
                break;

        }

        return Degree;
    }

    /// <summary>
    /// Μέθοδος που παίρνει την επιλογή του χρήστη και την κωδικοποιεί για να μπορεί να κληθεί η υπηρεσία
    /// </summary>
    /// <param name="d"> dropdownList από όπου βλέπει την επιλογή </param>
    /// <returns> κωδικοποιημένη σωστά επιλογή </returns>
    private net.webservicex.www.SpeedUnit encodeSpeed(DropDownList d)
    {
        net.webservicex.www.SpeedUnit speed = new net.webservicex.www.SpeedUnit();

        switch (d.SelectedIndex)
        {
            case 1:
                speed = net.webservicex.www.SpeedUnit.centimetersPersecond;
                break;
            case 2:
                speed = net.webservicex.www.SpeedUnit.metersPersecond;
                break;
            case 3:
                speed = net.webservicex.www.SpeedUnit.feetPersecond;
                break;
            case 4:
                speed = net.webservicex.www.SpeedUnit.feetPerminute;
                break;
            case 5:
                speed = net.webservicex.www.SpeedUnit.milesPerhour;
                break;
            case 6:
                speed = net.webservicex.www.SpeedUnit.kilometersPerhour;
                break;
            case 7:
                speed = net.webservicex.www.SpeedUnit.furlongsPermin;
                break;
            case 8:
                speed = net.webservicex.www.SpeedUnit.knots;
                break;
            case 9:
                speed = net.webservicex.www.SpeedUnit.leaguesPerday;
                break;
            case 10:
                speed = net.webservicex.www.SpeedUnit.Mach;
                break;
        }

        return speed;
    }

    /// <summary>
    /// Μέθοδος που παίρνει την επιλογή του χρήστη και την κωδικοποιεί για να μπορεί να κληθεί η υπηρεσία
    /// </summary>
    /// <param name="d"> dropdownList από όπου βλέπει την επιλογή </param>
    /// <returns> κωδικοποιημένη σωστά επιλογή </returns>
    private net.webservicex.www.WeightUnit encodeWeight(DropDownList d)
    {
        net.webservicex.www.WeightUnit weight = net.webservicex.www.WeightUnit.Carats;

        switch (d.SelectedIndex)
        {
            case 1:
                weight = net.webservicex.www.WeightUnit.Grains;
                break;
            case 2:
                weight = net.webservicex.www.WeightUnit.Scruples;
                break;
            case 3:
                weight = net.webservicex.www.WeightUnit.Carats;
                break;
            case 4:
                weight = net.webservicex.www.WeightUnit.Grams;
                break;
            case 5:
                weight = net.webservicex.www.WeightUnit.Pennyweight;
                break;
            case 6:
                weight = net.webservicex.www.WeightUnit.DramAvoir;
                break;
            case 7:
                weight = net.webservicex.www.WeightUnit.DramApoth;
                break;
            case 8:
                weight = net.webservicex.www.WeightUnit.OuncesAvoir;
                break;
            case 9:
                weight = net.webservicex.www.WeightUnit.OuncesTroyApoth;
                break;
            case 10:
                weight = net.webservicex.www.WeightUnit.Poundals;
                break;
            case 11:
                weight = net.webservicex.www.WeightUnit.PoundsTroy;
                break;
            case 12:
                weight = net.webservicex.www.WeightUnit.PoundsAvoir;
                break;
            case 13:
                weight = net.webservicex.www.WeightUnit.Kilograms;
                break;
            case 14:
                weight = net.webservicex.www.WeightUnit.Stones;
                break;
            case 15:
                weight = net.webservicex.www.WeightUnit.QuarterUS;
                break;
            case 16:
                weight = net.webservicex.www.WeightUnit.Slugs;
                break;
            case 17:
                weight = net.webservicex.www.WeightUnit.weight100UScwt;
                break;
            case 18:
                weight = net.webservicex.www.WeightUnit.ShortTons;
                break;
            case 19:
                weight = net.webservicex.www.WeightUnit.MetricTonsTonne;
                break;
            case 20:
                weight = net.webservicex.www.WeightUnit.LongTons;
                break;

        }

        return weight;

    }

    /// <summary>
    /// Μέθοδος που παίρνει την επιλογή του χρήστη και την κωδικοποιεί για να μπορεί να κληθεί η υπηρεσία
    /// </summary>
    /// <param name="d"> dropdownList από όπου βλέπει την επιλογή </param>
    /// <returns> κωδικοποιημένη σωστά επιλογή </returns>
    private net.webservicex.www.Computers encodeComputer(DropDownList d)
    {
        net.webservicex.www.Computers size = new net.webservicex.www.Computers();

        switch (d.SelectedIndex)
        {
            case 1:
                size = net.webservicex.www.Computers.Bit;
                break;
            case 2:
                size = net.webservicex.www.Computers.Byte;
                break;
            case 3:
                size = net.webservicex.www.Computers.Kilobyte;
                break;
            case 4:
                size = net.webservicex.www.Computers.Megabyte;
                break;
            case 5:
                size = net.webservicex.www.Computers.Gigabyte;
                break;
            case 6:
                size = net.webservicex.www.Computers.Terabyte;
                break;
            case 7:
                size = net.webservicex.www.Computers.Petabyte;
                break;
        }

        return size;
    }

}