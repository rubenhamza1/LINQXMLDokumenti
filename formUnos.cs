using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.IO;

namespace LINQXMLDocs
{
    public partial class formUnos : Form
    {
        List<Osoba> osobe = new List<Osoba>();
        string dokument = "osobe.xml";
        public formUnos()
        {
            InitializeComponent();
        }

        private void btnUnos_Click(object sender, EventArgs e)
        {
            Osoba osoba = new Osoba(txtIme.Text, txtPrezime.Text,
                Convert.ToInt32(txtGodRod.Text));

            osobe.Add(osoba);

            DialogResult upit = MessageBox.Show("Želite li upisati još osoba? ", "Upit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (upit == DialogResult.Yes)
            {
                txtGodRod.Clear();
                txtIme.Clear();
                txtPrezime.Clear();
            }
            else
            {
                var OsobeXml = new XDocument();
                OsobeXml.Add(new XElement("Osobe"));
                foreach (Osoba o in osobe)
                {
                    var Osoba = new XElement("Osoba",
                    new XElement("Ime", osoba.Ime),
                    new XElement("Prezime", osoba.Prezime),
                    new XElement("GodRodenja", osoba.GodRodenja));
                    OsobeXml.Root.Add(Osoba);
                }
                /*
                if (File.Exists(dokument))
                {
                    DialogResult overwrite = MessageBox.Show("Dokument već postoji", "\r\nŽelite li prepisati stari dokument?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                    if (overwrite == DialogResult.Yes)
                    {
                        OsobeXml.Save(dokument);
                    }
                    else
                    {
                        SaveFileDialog noviDokument = new SaveFileDialog();
                        noviDokument.InitialDirectory = @"C:\";
                        noviDokument.Title = "Spremi novi dokument";
                        noviDokument.DefaultExt = "xml";
                        noviDokument.ShowDialog();

                        dokument = noviDokument.FileName;
                    }
                }
                */
                this.Close();
            }
        }
    }
}
