using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using NationalInstruments.Visa;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace test.PowerSupply
{
    public partial class Form1 : Form
    {
        private MessageBasedSession mbSession;
        ResourceManager rmSession = new ResourceManager();
        public Form1()
        {

            ///creates the manager to talk to the PSU
            InitializeComponent();
            using (var rmSession = new ResourceManager())
            {
                var resources = rmSession.Find("(ASRL|GPIB|TCPIP|USB)?*");
                foreach (string s in resources)
                {
                    COM.Items.Add(s);
                }
            }

            try
            {
                mbSession = (MessageBasedSession)rmSession.Open(COM.Text);
               
            }
            ///confirms the sessiona and connection to the session
            catch (InvalidCastException)
            {
                MessageBox.Show("Resource selected must be a message-based session");
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        ///Open Session
        {

                    using (var rmSession = new ResourceManager())
                    {
                        try
                        {
                    mbSession = (MessageBasedSession)rmSession.Open(COM.Text);
                    MessageBox.Show("Connection Confirmed");

                }
                        catch (InvalidCastException)
                        {
                            MessageBox.Show("Resource selected must be a message-based session");
                        }
                        catch (Exception exp)
                        {
                            MessageBox.Show(exp.Message);
                        }
                        finally
                        {
                            Cursor.Current = Cursors.Default;
                        }
                    }
                }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void COM_DoubleClick(object sender, EventArgs e)
        {
            string selected = (string)COM.SelectedItem;
            textBox1.Text = selected;
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {

        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            mbSession.RawIO.Write("V1O?\n");
        }

        private void button2_Click(object sender, EventArgs e)
            ///Checks the current numbers of the 1PSU
        {
            mbSession.RawIO.Write("V1?\n");
            textBox3.Text = mbSession.RawIO.ReadString();
            mbSession.RawIO.Write("I1?\n");
            textBox5.Text = mbSession.RawIO.ReadString();
           
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
            ///Checks the currents numbers on PSU2
        {
            mbSession.RawIO.Write("V2?\n");
            textBox8.Text = mbSession.RawIO.ReadString();
            mbSession.RawIO.Write("I2?\n");
            textBox6.Text = mbSession.RawIO.ReadString();
        }

        private void button4_Click(object sender, EventArgs e)
            ///PSU On BTn1
        {
            mbSession.RawIO.Write("OP1 1\n");
        }

        private void button6_Click(object sender, EventArgs e)
            ///PSU Off BTn 1
        {
            mbSession.RawIO.Write("OP1 0\n");
        }

        private void button5_Click(object sender, EventArgs e)
            ///PSU On BTn 2
        {
            mbSession.RawIO.Write("OP2 1\n");

        }

        private void button7_Click(object sender, EventArgs e)
            ///PSU Off BTn 2
        {
            mbSession.RawIO.Write("OP2 0\n");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
            ///Setting the current voltage for PSU1
        {
            mbSession.RawIO.Write("V1 " + textBox2.Text + "\n");
            
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
            ///Setting the current voltage for PSU2
        {
            mbSession.RawIO.Write("V2 " + textBox9.Text+ "\n");
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
            ///Settings the current amperhage for PS1
        {
            mbSession.RawIO.Write("I1 " + textBox4.Text+ "\n");
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
            ///Settings the current amperhage for PS2
        {
            mbSession.RawIO.Write("I2 " + textBox7.Text+ "\n");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

        }

       

        
       