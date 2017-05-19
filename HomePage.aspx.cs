using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public partial class HomePage : System.Web.UI.Page
{
    private String[] elements = new String[119]; // πίνακας με τα ονόματα των στοιχείων
    private String fileName = "Elements.txt";   // αρχείο από το οποίο θα φορτώνονται τα ονόματα των στοιχείων.
    net.webservicex.www.periodictable perTable = new net.webservicex.www.periodictable();

    /// <summary>
    /// Καλείται κατά την φόρτωση και γίνεται η λειτουργία της υπηρεσίας.
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            dropDownListElements.Items.Add("-Select Element-");
            string xmlResponse = perTable.GetAtoms();

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlResponse);

            XmlNodeList nodes = doc.DocumentElement.SelectNodes("//Table");

            foreach (XmlNode node in nodes)
            {
                dropDownListElements.Items.Add(node["ElementName"].InnerText);
            }

            dropDownListInformationGet.Items.Add("-Select Information-");
            dropDownListInformationGet.Items.Add("Atomic Number");
            dropDownListInformationGet.Items.Add("Atomic Weight");
            dropDownListInformationGet.Items.Add("Element Symbol");
            dropDownListInformationGet.Items.Add("Boiling Point");
            dropDownListInformationGet.Items.Add("Melting Point");

        }
        else if ( dropDownListElements.SelectedIndex == 0 )
        {
            HError.InnerText = "You have to choose an element from the list.";
            divError.Visible = true;
        }
        else
        {
            makeInvisible();

            Boolean flag = false;
            List<string> allInfo = new List<string>();
            string choice = "";
            string res = "";
            string el = dropDownListElements.SelectedValue.ToString();
            switch (dropDownListInformationGet.SelectedIndex)
            {
                case 1:
                    res = GetAtomicNumber();
                    choice = " atomic number ";
                    break;
                case 2:
                    res = GetAtomicWeight();
                    choice = " atomic weight ";
                    break;
                case 3:
                    res = GetElementSymbol();
                    choice = " element symbol ";
                    break;
                case 4:
                    res = GetBoilingPoint();
                    choice = " boiling point ";
                    break;
                case 5:
                    res = GetMeltingPoint();
                    choice = " melting point ";
                    break;
                default:
                    allInfo = btnGetAll_Click();
                    flag = true;
                    break;
            }

            if (!flag)
            { 
                resultMessage.InnerText = "The" + choice + "of the element " + el + " is " + res + "!!!";
                divResultMessage.Visible = true;
            }
            else
            {
                
                H1.InnerText = allInfo[0]; div1.Visible = true;
                H2.InnerText = allInfo[1]; div2.Visible = true;
                H3.InnerText = allInfo[2]; div3.Visible = true;
                H4.InnerText = allInfo[3]; div4.Visible = true;
                H5.InnerText = allInfo[4]; div5.Visible = true;
                H6.InnerText = allInfo[5]; div6.Visible = true;
                if (allInfo.Count > 6)
                {
                    H7.InnerText = allInfo[6]; div7.Visible = true;
                }
                if (allInfo.Count > 7)
                {
                    H8.InnerText = allInfo[7]; div8.Visible = true;
                }
                if (allInfo.Count > 8)
                {
                    H9.InnerText = allInfo[8]; div9.Visible = true;
                }
                if (allInfo.Count > 9)
                {
                    H10.InnerText = allInfo[9]; div10.Visible = true;
                }
               

            }
        }

    }

    /// <summary>
    /// Μέθοδος που καλεί μέσω της υπηρεσίας τον ατομικό αριθμό του στοιχείου που επιλέχθηκε.
    /// Χρησιμοποιεί την βοηθητική μέθοδο getSelectedElementInformation()
    /// </summary>
    /// <returns> τον ατομικό αριθμό </returns>
    private string GetAtomicNumber()
    {
        return getSelectedElementInformation("AtomicNumber");
    }

    /// <summary>
    /// Μέθοδος που καλεί μέσω της υπηρεσίας το ατομικό βάρος του στοιχείου.
    /// Χρησιμοποιεί την βοηθητική μέθοδο getSelectedElementInformation()
    /// </summary>
    /// <returns> το ατομικό βάρος </returns>
    private string GetAtomicWeight()
    {
        return getSelectedElementInformation("AtomicWeight");
    }

    /// <summary>
    /// Μέθοδος που βρίσκει το σύμβολο του επιλεγμένου στοιχείου μέσω της υπηρεσίας.
    /// Χρησιμοποιεί την βοηθητική μέθοδο getSelectedElementInformation()
    /// </summary>
    /// <returns> το σύμβολο </returns>
    private string GetElementSymbol()
    {
        return getSelectedElementInformation("Symbol");
    }

    /// <summary>
    /// Μέθοδος που βρίσκει το σημείο βρασμού του επιλεγμένου στοιχείου μέσω της υπηρεσίας.
    /// Χρησιμοποιεί την βοηθητική μέθοδο getSelectedElementInformation()
    /// </summary>
    /// <returns> το σημείο βρασμού </returns>
    private string GetBoilingPoint()
    {
        return getSelectedElementInformation("BoilingPoint");
    }

    /// <summary>
    /// Μέθοδος που βρίσκει το σημείο τήξης του επιλεγμένου στοιχείου μέσω της υπηρεσίας.
    /// Χρησιμοποιεί την βοηθητική μέθοδο getSelectedElementInformation()
    /// </summary>
    /// <returns> το σημείο τήξης </returns>
    private string GetMeltingPoint()
    {
        return getSelectedElementInformation("MeltingPoint");
    }

    /// <summary>
    /// Μέθοδος που παίρνει από την υπηρεσία όλες τις πληροφορίες για ένα στοιχείο.
    /// </summary>
    /// <param name="info"> επιλογή επιθυμητής πληροφορίας </param>
    /// <returns> την συγκεκριμένη μόνο πληροφορία </returns>
    private string getSelectedElementInformation(string info)
    {
        string selectedElement = dropDownListElements.SelectedValue.ToString();

        XmlDocument doc = new XmlDocument();
        doc.LoadXml(perTable.GetAtomicNumber(selectedElement));

        string s = "//" + info;
        XmlNode n = doc.DocumentElement.SelectSingleNode(s);

        return n.InnerText;
    }

    /// <summary>
    /// Μέθοδος που παίρνει όλες τις διαθέσιμες πληροφορίες για το στοιχείο που θέλουμε.
    /// </summary>
    /// <returns> λίστα με όνομα και πληροφορίες του στοιχείου. </returns>
    private List<string> btnGetAll_Click()
    {
        string selectedElement = dropDownListElements.SelectedValue.ToString();

        XmlDocument doc = new XmlDocument();
        doc.LoadXml(perTable.GetAtomicNumber(selectedElement));
        string s = "";
        XmlNodeList nodes = doc.DocumentElement.SelectNodes("//Table");
        XmlNodeList v = null;
        foreach (XmlNode node in nodes)
        {
            v = node.ChildNodes;
        }

        // Λίστα με τις πληροφορίες (τίτλους).
        List<string> infos = new List<string>();
        infos.Add("atomic number"); infos.Add("element name"); infos.Add("element symbol");
        infos.Add("atomic weight"); infos.Add("boiling point"); infos.Add("ionisation potential");
        infos.Add("eletro negativity"); infos.Add("atomic radius");
        infos.Add("melting point"); infos.Add("density");

        // Λίστα για τις πληροφορίες (τιμές).
        List<string> infoValues = new List<string>();
        

        foreach(XmlNode node in v)
        {
            infoValues.Add("The " + node.Name + " of the element " + selectedElement + " is " + node.InnerXml + "!!!");
            
        }
        
        return infoValues;
    }

    /// <summary>
    /// Μέθοδος που κάνει αόρατα τα μηνυματάκια.
    /// </summary>
    private void makeInvisible()
    {
        div1.Visible = false; div2.Visible = false; div3.Visible = false;
        div4.Visible = false; div5.Visible = false; div6.Visible = false;
        div7.Visible = false; div8.Visible = false; div9.Visible = false;
        div10.Visible = false;

        divError.Visible = false;
    }

}