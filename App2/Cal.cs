using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2
{
    public class Cal
    {
        private int score;
        private int lammat;
        private int call;
        private bool iscall;
        private bool iswith;
        private bool onlywin;
        private bool onlylose;
        private bool isdash;
        private int risk;
        public int gamestate;
        private bool isoverlose;
        private bool triplerisk;
        private bool winget13;
        private bool newsupercall;

        public Cal(int lammat, int call, bool iscall, bool iswith, bool isdash, bool onlywin, bool onlylose, int Risk,int gamestate)
        {
            this.lammat = lammat;
            this.call = call;
            this.iscall = iscall;
            this.iswith = iswith;
            this.onlywin = onlywin;
            this.onlylose = onlylose;
            this.isdash = isdash;
            this.risk = Risk;
            this.gamestate = gamestate;
            var obj = App.Current as App;
            isoverlose = obj.isoverlose;
            triplerisk = obj.triplerisk;
            winget13 = obj.winget13;
            newsupercall = obj.newsupercall;
        }

        public void Loserscore()
        {
            if (call > 7 && iscall)
            {
                
                if (newsupercall)
                    score = score - ((8 * 8) + ((call - 8) * 10));
                else
                { score = score - ((call * call) / 2); }
            }
            else {
                if (isdash)
                    score = score - 33;
                else {

                    score = score - Math.Abs(call - lammat);
                    if (iscall || iswith)
                        score = score - 10;
                    if (gamestate > 0 && lammat < call && isoverlose)
                        score = score - 10;
                    if (gamestate < 0 && lammat > call && isoverlose)
                        score = score - 10;
                    if (onlylose)
                        score = score - 10;
                    if (risk == 1)
                        score = score - 10;
                    if (risk == 2)
                        score = score - 20;
                    if (risk > 2 && triplerisk)
                        score = score - 30;
                    if (!triplerisk && risk > 2)
                        score = score - 20;



                }
            }
        }

        public void Winnerscore()
        {
            if (call > 7 && iscall)
            {if (newsupercall)
                    score = score + ((8 * 8) + ((call-8) * 10));
                else
                { score = score + (lammat * lammat); }

            }
            else {
                if (isdash)
                    score = score + 33;
                else {
                    if (winget13)
                        score = score + (13 + lammat);
                    if (!winget13)
                        score = score + (10 + lammat);
                    if (iscall || iswith)
                        score = score + 10;
                    if (onlywin)
                        score = score + 10;
                    if (risk == 1)
                        score = score + 10;
                    if (risk == 2)
                        score = score + 20;
                    if (risk > 2 && triplerisk)
                        score = score + 30;
                    if (!triplerisk && risk > 2)
                        score = score + 20;

                }
            }

        }

        public int getScore()
        {

            if (call == lammat)
                Winnerscore();
            else
                Loserscore();
            return score;
        }

        public void setScore(int score)
        {
            this.score = score;
        }

    }

}

