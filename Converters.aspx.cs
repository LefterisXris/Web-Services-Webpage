using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Converters : System.Web.UI.Page
{
    net.webservicex.www.ConvertTemperature convTemp = new net.webservicex.www.ConvertTemperature();
    net.webservicex.www.ConvertSpeeds convSpeeds = new net.webservicex.www.ConvertSpeeds();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            // Temperature
            dropDownListTempFrom.Items.Add("-Select-"); dropDownListTempFrom.Items.Add("Celsius");
            dropDownListTempFrom.Items.Add("Fahrenheit");  dropDownListTempFrom.Items.Add("Rankine");
            dropDownListTempFrom.Items.Add("Reaumur"); dropDownListTempFrom.Items.Add("kelvin");

            dropDownListTempTo.Items.Add("-Select-"); dropDownListTempTo.Items.Add("Celsius");
            dropDownListTempTo.Items.Add("Fahrenheit"); dropDownListTempTo.Items.Add("Rankine");
            dropDownListTempTo.Items.Add("Reaumur"); dropDownListTempTo.Items.Add("kelvin");


            //Speed
            dropDownListSpeedFrom.Items.Add("-Select-"); dropDownListSpeedFrom.Items.Add("centimeters per second");
            dropDownListSpeedFrom.Items.Add("meters per second"); dropDownListSpeedFrom.Items.Add("feet per second");
            dropDownListSpeedFrom.Items.Add("feet per minute"); dropDownListSpeedFrom.Items.Add("miles per hour");
            dropDownListSpeedFrom.Items.Add("kilometers per hour"); dropDownListSpeedFrom.Items.Add("furlongs per minute");
            dropDownListSpeedFrom.Items.Add("knots"); dropDownListSpeedFrom.Items.Add("leagues per day");
            dropDownListSpeedFrom.Items.Add("mach");

            dropDownListSpeedTo.Items.Add("-Select-"); dropDownListSpeedTo.Items.Add("centimeters per second");
            dropDownListSpeedTo.Items.Add("meters per second"); dropDownListSpeedTo.Items.Add("feet per second");
            dropDownListSpeedTo.Items.Add("feet per minute"); dropDownListSpeedTo.Items.Add("miles per hour");
            dropDownListSpeedTo.Items.Add("kilometers per hour"); dropDownListSpeedTo.Items.Add("furlongs per minute");
            dropDownListSpeedTo.Items.Add("knots"); dropDownListSpeedTo.Items.Add("leagues per day");
            dropDownListSpeedTo.Items.Add("mach");
        }
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

            double newSpeed = convSpeeds.ConvertSpeed(speed, speedFrom, speedTo);

            textBoxSpeedResult.Text = newSpeed.ToString();
            textBoxSpeedResult.Visible = true;
            
        }
    }


    protected void WeightConverter(object sender, EventArgs e)
    {

    }

    protected void ComputerUnitConverter(object sender, EventArgs e)
    {

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

}