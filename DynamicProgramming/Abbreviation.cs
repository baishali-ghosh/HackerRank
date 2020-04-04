using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution {
   
    // Complete the abbreviation function below.
    static string abbreviation(string a, string b) {
        if(abbreviationHelper(a, b, 0, 0))
            return "YES";
        else
            return "NO";
    }

     static bool abbreviationHelper(string a, string b, int i, int j) {
         //both exhausted
        if(i == a.Length && j == b.Length)
            return true;
        // a over but b is not
        else if(i == a.Length)
            return false;
            
        //b is exhausted, we have an answer if remaining chars in a are lowercase
        else if( j == b.Length ){
            return checkIfAllLower(a,i);
        }
         
        bool s1 = false, s2 = false, s3 =false;
        //both characters are equal, check for remaining lengths of both strings
        if(a[i] == b[j])
        {
            s1 = abbreviationHelper(a, b, i+1, j+1);
        }
        //Try both paths
        else{     
            if(Char.IsLower(a[i])){
                //delete lowercase
                s2 = abbreviationHelper(a,b, i+1, j);
                //capitalize lowercase only if it matches b[j]
                if(Char.ToUpper(b[j]) == Char.ToUpper(a[i])){
                    s3 = abbreviationHelper(a, b, i+1, j+1);
                }
            }
        }
        return s1 || s2 || s3;
    }

    static bool checkIfAllLower(string a, int x){
        for(int i=x;i<a.Length; i++){
            if(Char.IsUpper(a[i])){
                return false;
            }
        }
        return true;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine());

        for (int qItr = 0; qItr < q; qItr++) {
            string a = Console.ReadLine();

            string b = Console.ReadLine();

            string result = abbreviation(a, b);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
