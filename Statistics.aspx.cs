using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Statistics : System.Web.UI.Page
{
    net.webservicex.www.Statistics stat = new net.webservicex.www.Statistics();

    /// <summary>
    /// Καλείται κατά την φόρτωση και γίνεται η λειτουργία της υπηρεσίας.
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            string s = textAreaNumbers.InnerText;

            if (s == "")
            {
                H6.InnerText = "You have to insert some numbers in the area first.";
                div6.Visible = true;
            }
            else
            {
                div6.Visible = false;
                // Χωρίζω στα κόμμα.
                List<string> numbers = s.Split(',').ToList<string>();

                // Σβήνω τα κενά και τα αχρείαστα.
                for (int i = 0; i < numbers.Count; i++)
                {
                    numbers[i] = Regex.Replace(numbers[i], @"\s", "");
                }

                // Μετατροπή σε δεκαδικούς.
                double[] numbs = new double[numbers.Count];
                for (int i = 0; i < numbers.Count; i++)
                {
                    numbs[i] = Convert.ToDouble(numbers[i]);
                }

                // Κλήση της υπηρεσίας.
                CalculateStatistics(numbs);
            }
        }

    }

    /// <summary>
    /// Μέθοδος που καλεί την υπηρεσία και παίρνει πίσω τα στατιστικά αποτελέσματα.
    /// </summary>
    /// <param name="numbers"> πίνακας με τους αριθμούς για τον υπολογισμό. </param>
    private void CalculateStatistics(double[] numbers)
    {
        double sum, average, sDeviation, skewness, kyrtosis;

        sum = stat.GetStatistics(numbers, out average, out sDeviation, out skewness, out kyrtosis);

        H1.InnerText = "The Sum is: " + sum; div1.Visible = true;
        H2.InnerText = "The Average is: " + average; div2.Visible = true;
        H3.InnerText = "The Standard Deviation is: " + sDeviation; div3.Visible = true;
        H4.InnerText = "The Skewness is: " + skewness; div4.Visible = true;
        H5.InnerText = "The Kyrtosis is: " + kyrtosis; div5.Visible = true;



    }

}