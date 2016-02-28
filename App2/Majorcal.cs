using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2
{
    
    public class Majorcal
    {
        private int call1;
        private int lammat1;
        public bool iscall1 = false;
        public bool iswith1 = false;
        private bool isdash1;
        private bool sa3ayda = false;
        private Cal c;
        private bool error = false;
        private bool onlywin1 = false;
        private bool onlylose1 = false;
        private int Risk1 = 0;
        private int call2;
        private int lammat2;
        public bool iscall2 = false;
        public bool iswith2 = false;
        private bool isdash2;
        private bool onlywin2 = false;
        private bool onlylose2 = false;
        private int Risk2 = 0;
        private int call3;
        private int lammat3;
        public bool iscall3 = false;
        public bool iswith3 = false;
        private bool isdash3;
        private bool doubled = false;
        private bool onlywin3 = false;
        private bool onlylose3 = false;
        private int Risk3 = 0;
        private int call4;
        private int lammat4;
        public bool iscall4 = false;
        public bool iswith4 = false;
        private bool isdash4;
        private bool onlywin4 = false;
        private bool onlylose4 = false;
        private int Risk4 = 0;
        private int doub = 0;
        private int gameno;

        public Majorcal(int call1,int call2,int call3,int call4)
        {
            this.call1 = call1;
            this.call2 = call2;
            this.call3 = call3;
            this.call4 = call4;
        }
        public Majorcal(int call1, int lammat1, bool dash1, int call2, int lammat2, bool dash2, int call3, int lammat3, bool dash3, int call4, int lammat4, bool dash4,int gameno)
        {
            this.call1 = call1;
            this.lammat1 = lammat1;
            isdash1 = dash1;
            this.call2 = call2;
            this.lammat2 = lammat2;
            isdash2 = dash2;
            this.call3 = call3;
            this.lammat3 = lammat3;
            isdash3 = dash3;
            this.call4 = call4;
            this.lammat4 = lammat4;
            isdash4 = dash4;
            if (lammat1 + lammat2 + lammat3 + lammat4 != 13)
                error = true;
            if (dash1)
                doub++;
            if (dash2)
                doub++;
            if (dash3)
                doub++;
            if (dash4)
                doub++;
            this.gameno = gameno;

        }
        public void setrisk()
        {
            if (Math.Abs(call1 + call2 + call3 + call4 - 13) == 2 && iscall4)
            {if (!isdash3)
                    Risk3 = 1;
                else 
                    Risk2 = 1;
            }
            if (Math.Abs(call1 + call2 + call3 + call4 - 13) == 2 && iscall1)
            {
                if (!isdash4)
                    Risk4 = 1;
                else
                    Risk3 = 1;
            }

            if (Math.Abs(call1 + call2 + call3 + call4 - 13) == 2 && iscall3)
            {
                if (!isdash2)
                    Risk2 = 1;
                else
                    Risk1 = 1;
            }
            if (Math.Abs(call1 + call2 + call3 + call4 - 13) == 2 && iscall2)
               
            {
                if (!isdash1)
                    Risk1 = 1;
                else
                    Risk4 = 1;
            }
            if (Math.Abs(call1 + call2 + call3 + call4 - 13) == 3 && iscall4)
               
            {
                if (!isdash3)
                    Risk3 = 2;
                else
                    Risk2 = 2;
            }
            if (Math.Abs(call1 + call2 + call3 + call4 - 13) == 3 && iscall1)
            {
                if (!isdash4)
                    Risk4 = 2;
                else
                    Risk3 =2;
            }
            if (Math.Abs(call1 + call2 + call3 + call4 - 13) == 3 && iscall3)
            {
                if (!isdash2)
                    Risk2 = 2;
                else
                    Risk1 = 2;
            }
            if (Math.Abs(call1 + call2 + call3 + call4 - 13) == 3 && iscall2)
            {
                if (!isdash1)
                    Risk1 = 2;
                else
                    Risk4 = 2;
            }
            if (Math.Abs(call1 + call2 + call3 + call4 - 13) >=4 && iscall4)
               
            {
                if (!isdash3)
                    Risk3 = 3;
                else
                    Risk2 = 3;
            }
            if (Math.Abs(call1 + call2 + call3 + call4 - 13) >= 4 && iscall1)
            {
                if (!isdash4)
                    Risk4 = 3;
                else
                    Risk3 = 3;
            }
            if (Math.Abs(call1 + call2 + call3 + call4 - 13) >= 4 && iscall3)
               
            {
                if (!isdash2)
                    Risk2 = 3;
                else
                    Risk1 = 3;
            }
            if (Math.Abs(call1 + call2 + call3 + call4 - 13) >= 4 && iscall2)
            {
                if (!isdash1)
                    Risk1 = 3;
                else
                    Risk4 = 3;
            }

        }
        public void setiscall()
        {
            if (call1 >= call2 && call1 >= call3 && call1 >= call4)
            {
                iscall1 = true;
                if (call1 == call2)
                {
                    iswith2 = true;
                    doub++;
                }
                if (call1 == call3)
                { iswith3 = true; doub++; }
                if (call1 == call4)
                {
                    iswith4 = true;
                    doub++;
                }
            }
            if (call2 >= call1 && call2 >= call3 && call2 >= call4)
            {
                iscall2 = true;
                if (call1 == call2)
                { iswith1 = true; doub++; }
                if (call2 == call3)
                { iswith3 = true; doub++; }
                if (call2 == call4)
                { iswith4 = true; doub++; }
            }
            if (call3 >= call2 && call3 >= call1 && call3 >= call4)
            {
                iscall3 = true;
                if (call3 == call2)
                { iswith2 = true; doub++; }
                if (call3 == call1)
                { iswith1 = true; doub++; }
                if (call3 == call4)
                { iswith4 = true; doub++; }
            }
            if (call4 >= call2 && call4 >= call3 && call4 >= call1)
            {
                iscall4 = true;
                if (call4 == call2)
                { iswith2 = true; doub++; }
                if (call4 == call3)
                { iswith3 = true; doub++; }
                if (call4 == call1)
                { iswith1 = true; doub++; }
            }
            if (doub >= 3)
                doubled = true;
            if (gameno % 4 == 1)
            {
                if (iscall1)
                {
                    iscall2 = false;
                    iscall3 = false;
                    iscall4 = false;

                }
                if (iscall2)
                {

                    iscall3 = false;
                    iscall4 = false;

                }
                if (iscall3)
                {
                    iscall4 = false;
                }
            }
            if (gameno % 4 == 2)
            {
                if (iscall2)
                {
                    iscall1 = false;
                    iscall3 = false;
                    iscall4 = false;

                }
                if (iscall3)
                {

                    iscall1 = false;
                    iscall4 = false;

                }
                if (iscall4)
                {
                    iscall1 = false;
                }
            }
            if (gameno % 4 == 3)
            {
                if (iscall3)
                {
                    iscall1 = false;
                    iscall2 = false;
                    iscall4 = false;

                }
                if (iscall4)
                {

                    iscall1 = false;
                    iscall2 = false;

                }
                if (iscall1)
                {
                    iscall2 = false;
                }
            }
            if (gameno % 4 == 0)
            {
                if (iscall4)
                {
                    iscall2 = false;
                    iscall3 = false;
                    iscall1 = false;

                }
                if (iscall1)
                {

                    iscall3 = false;
                    iscall2 = false;

                }
                if (iscall2)
                {
                    iscall3 = false;
                }
            }

        }
        public void setonlywinner()
        {
            bool win1 = false;
            bool win2 = false;
            bool win3 = false;
            bool win4 = false;
            int x = 0;
            if (call1 == lammat1)
            {
                win1 = true;
                x++;
            }
            if (call2 == lammat2)
            {
                win2 = true;
                x++;
            }
            if (call3 == lammat3)
            {
                win3 = true;
                x++;
            }
            if (call4 == lammat4)
            {
                win4 = true;
                x++;
            }
            if (x == 0)
                setSa3ayda(true);

            if (x >= 4)
                setError(true);
            if (x == 1)
            {
                if (win1)
                    onlywin1 = true;
                if (win2)
                    onlywin2 = true;
                if (win3)
                    onlywin3 = true;
                if (win4)
                    onlywin4 = true;
            }
            if (x == 3)
            {
                if (!win1)
                    onlylose1 = true;
                if (!win2)
                    onlylose2 = true;
                if (!win3)
                    onlylose3 = true;
                if (!win4)
                    onlylose4 = true;
            }

        }

        internal bool isDoubled()
        {
            return doubled;
        }

        public int getscore1(int score)
        {
            c = new Cal(lammat1, call1, iscall1, iswith1, isdash1, onlywin1, onlylose1, Risk1);
            c.setScore(score);
          
                return c.getScore();
           
        }
        public int getscore2(int score)
        {
            c = new Cal(lammat2, call2, iscall2, iswith2, isdash2, onlywin2, onlylose2, Risk2);
            c.setScore(score);
           
                return c.getScore() ;
        }
        public int getscore3(int score)
        {
            c = new Cal(lammat3, call3, iscall3, iswith3, isdash3, onlywin3, onlylose3, Risk3);
            c.setScore(score);
           
                return c.getScore();
            
        }
        public int getscore4(int score)
        {
            c = new Cal(lammat4, call4, iscall4, iswith4, isdash4, onlywin4, onlylose4, Risk4);
            c.setScore(score);
           
                return c.getScore();
           
        }


        public bool isError()
        {
            return error;
        }

        public void setError(bool error)
        {
            this.error = error;
        }





        public bool isSa3ayda()
        {
            return sa3ayda;
        }

        public void setSa3ayda(bool sa3ayda)
        {
            this.sa3ayda = sa3ayda;
        }
    }

}
