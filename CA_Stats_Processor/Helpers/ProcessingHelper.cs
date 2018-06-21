using System;
using System.IO;
using System.Text;

namespace CA_Stats_Processor.Helpers
{
    //If we want to optimize it, we can put all of this into a single function but because the low complexity, there's no reason to worry about processing speedcat 
    public class ProcessingHelper
    {

        public static Tuple<int,int> ThirtyAndSixty(string[,] array){
            var thirties = 0;
            var sixties = 0;
            var startTime = Convert.ToDateTime(array[0, 0]);
            var started = false;
            var csv = new StringBuilder();


            //after your loop

            for (int i = 0; i < array.GetLength(0); i++)
            {
                if (array[i, 1] != "COMPLETE")
                {
                    if(!started){
                        started = true;
                        //These if cover if the first entry is not valid
                        if(array[i-1,0]!= null){ 
                            startTime = Convert.ToDateTime(array[i - 1, 0]);

                        }
                        else if (array[i - 1, 0] == null){
                            startTime = Convert.ToDateTime(array[i, 0]);
                        }

                    }


                }else if(array[i,1] == "COMPLETE"){
                    if(started){
                        started = false;
                        if((Convert.ToDateTime(array[i, 0]) - startTime).TotalMinutes > 30){
                thirties += 1;
                            var newLine = string.Format("{0},{1},{2}", startTime, Convert.ToDateTime(array[i,0]), 30);
                            csv.AppendLine(newLine);
                        }
                        if ((Convert.ToDateTime(array[i, 0]) - startTime).TotalMinutes > 60)
                        {
                            var newLine = string.Format("{0},{1},{2}", startTime, Convert.ToDateTime(array[i, 0]), 60);
                            csv.AppendLine(newLine);
                            sixties += 1;
                        }
                    }
                }
            }
            File.WriteAllText(@"Output.csv", csv.ToString());
            return new Tuple<int, int>(thirties, sixties);
        }
    }
}
