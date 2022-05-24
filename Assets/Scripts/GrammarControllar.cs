using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrammarControllar : MonoBehaviour
{
    char[] a = new char[2000];
    char[] b = new char[2000];
    char[] d = new char[2000];
    char[] e = new char[2000];
    char ch;
    //flag=1处理非终结符，flag=0处理终结符
    int n1, i1 = 0, flag = 1, n = 5; 
    int total = 0;
    Text grammarText;
    void Start()
    {
        grammarText = GameObject.Find("GrammarText").GetComponent<Text>();
        grammarText.text = null;
    }
    /// <summary>
    /// 子程序E1
    /// </summary>
    /// <returns>有语法错误函数返回值为0，否则为1</returns>
    private int E1()
    {
        int f, t;
        grammarText.text += total + "\t\t\tE-->TG\t\t\t";
        total++;
        flag = 1;
        input();
        input1();
        f = T();
        if (f == 0)
        {
            return 0;
        }

        t = G();
        if (t == 0)
        {
            return 0;
        }
        else
        {
            return 1;
        }
    }
    /// <summary>
    /// 子程序E
    /// </summary>
    /// <returns>有语法错误函数返回值为0，否则为1</returns>
    private int E()
    {
        int f, t;
        grammarText.text += total + "\t\t\tE-->TG\t\t\t";
        total++;
        e[0] = 'E';
        e[1] = '=';
        e[2] = '>';
        e[3] = 'T';
        e[4] = 'G';
        e[5] = '#';
        output();
        flag = 1;
        input();
        input1();
        f = T();
        if (f == 0)
        {
            return 0;
        }
        t = G();
        if (t == 0)
        {
            return 0;
        }
        else
        {
            return 1;
        }
    }
    /// <summary>
    /// 子程序S
    /// </summary>
    /// <returns>有语法错误函数返回值为0，否则为1</returns>
    private int S()
    {
        int f, t;
        if (ch == '*')
        {
            b[i1] = ch;
            grammarText.text += total + "\t\t\tS-->*FS\t\t";
            total++;
            e[0] = 'S';
            e[1] = '=';
            e[2] = '>';
            e[3] = '*';
            e[4] = 'F';
            e[5] = 'S';
            e[6] = '#';
            output();
            flag = 0;
            input();
            input1();
            ch = a[++i1];
            f = F();
            if (f == 0)
            {
                return 0;
            }
            t = S();
            if (t == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        else if (ch == '/')
        {
            b[i1] = ch;
            grammarText.text += total + "\t\t\tS-->/FS\t\t\t";
            total++;
            e[0] = 'S';
            e[1] = '=';
            e[2] = '>';
            e[3] = '/';
            e[4] = 'F';
            e[5] = 'S';
            e[6] = '#';
            output();
            flag = 0;
            input();
            input1();
            ch = a[++i1];
            f = F();
            if (f == 0)
            {
                return 0;
            }
            t = S();
            if (t == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        grammarText.text += total + "\t\t\tS-->^\t\t\t";
        total++;
        e[0] = 'S';
        e[1] = '=';
        e[2] = '>';
        e[3] = '^';
        e[4] = '#';
        output();
        flag = 1;
        a[i1] = ch;
        input();
        input1();
        return 1;
    }
    /// <summary>
    /// 子程序T
    /// </summary>
    /// <returns>有语法错误函数返回值为0，否则为1</returns>
    private int T()
    {
        int f, t;
        grammarText.text += total + "\t\t\tT-->FS\t\t\t";
        total++;
        e[0] = 'T';
        e[1] = '=';
        e[2] = '>';
        e[3] = 'F';
        e[4] = 'S';
        e[5] = '#';
        output();
        flag = 1;
        input();
        input1();
        f = F();
        if (f == 0)
        {
            return 0;
        }
        t = S();
        if (t == 0)
        {
            return 0;
        }
        else
        {
            return 1;
        }
    }
    /// <summary>
    /// 子程序G
    /// </summary>
    /// <returns>有语法错误函数返回值为0，否则为1</returns>
    private int G()
    {
        int f;
        if (ch == '+')
        {
            b[i1] = ch;
            grammarText.text += total + "\t\t\tG-->+TG\t\t";
            total++;
            e[0] = 'G';
            e[1] = '=';
            e[2] = '>';
            e[3] = '+';
            e[4] = 'T';
            e[5] = 'G';
            e[6] = '#';
            output();
            flag = 0;
            input();
            input1();
            ch = a[++i1];
            f = T();
            if (f == 0)
            {
                return 0;
            }
            G();
            return 1;
        }
        else if (ch == '-')
        {
            b[i1] = ch;
            grammarText.text += total + "\t\t\tG-->-TG\t\t\t";
            total++;
            e[0] = 'G';
            e[1] = '=';
            e[2] = '>';
            e[3] = '-';
            e[4] = 'T';
            e[5] = 'G';
            e[6] = '#';
            output();
            flag = 0;
            input();
            input1();
            ch = a[++i1];
            f = T();
            if (f == 0)
            {
                return 0;
            }
            G();
            return 1;
        }
        grammarText.text += total + "\t\t\tG-->^\t\t\t";
        total++;
        e[0] = 'G';
        e[1] = '=';
        e[2] = '>';
        e[3] = '^';
        e[4] = '#';
        output();
        flag = 1;
        input();
        input1();
        return 1;
    }
    /// <summary>
    /// 子程序F
    /// </summary>
    /// <returns>有语法错误函数返回值为0，否则为1</returns>
    private int F()
    {
        int f;
        if (ch == '(')
        {
            b[i1] = ch;
            grammarText.text += total + "\t\t\tF-->(E)\t\t\t";
            total++;
            e[0] = 'F';
            e[1] = '=';
            e[2] = '>';
            e[3] = '(';
            e[4] = 'E';
            e[5] = ')';
            e[6] = '#';
            output();
            flag = 0;
            input();
            input1();
            ch = a[++i1];
            f = E();
            if (f == 0)
            {
                return 0;
            }
            if (ch == ')')
            {
                b[i1] = ch;
                grammarText.text += total + "\t\t\tF-->(E)\t\t\t";
                total++;
                flag = 0;
                input();
                input1();
                ch = a[++i1];
            }
            else
            {
                grammarText.text += "error\n";
                return 0;
            }
        }
        else if (ch == 'i')
        {
            b[i1] = ch;
            grammarText.text += total + "\t\t\tF-->i\t\t\t\t";
            total++;
            e[0] = 'F';
            e[1] = '=';
            e[2] = '>';
            e[3] = 'i';
            e[4] = '#';
            output();
            flag = 0;
            input();
            input1();
            ch = a[++i1];
        }
        else
        {
            grammarText.text += "error\n";
            return 0;
        }
        return 1;
    }
    /// <summary>
    /// 输出分析串和分析字符
    /// </summary>
    private void input()
    {
        int j = 0;
        for (; j <= i1 - flag; j++)
        {
            grammarText.text += b[j];//输出分析串
        }
        grammarText.text += "\t\t\t\t";
        grammarText.text += ch + "\t\t\t\t\t";//输出分析字符
    }
    /// <summary>
    /// 输出剩余字符
    /// </summary>
    private void input1()
    {
        int j;
        for (j = i1 + 1 - flag; j < n1; j++)
        {
            grammarText.text += a[j];//输出剩余字符
        }
        grammarText.text += "\n";
    }
    /// <summary>
    /// 推导式计算
    /// </summary>
    private void output()
    {
        int m, k, j, q;
        int i = 0;
        m = 0; k = 0; q = 0;
        i = n;
        d[n] = '='; d[n + 1] = '>';
        d[n + 2] = '#';
        n = n + 2;
        i = n;
        i = i - 2;
        while (d[i] != '>' && i != 0)
        {
            i--;
        }
        i++;
        while (d[i] != e[0])
        {
            i++;
        }
        q = i;
        m = q;
        k = q;
        while (d[m] != '>')
        {
            m--;
        }
        m++;
        while (m != q)
        {
            d[n] = d[m];
            m++;
            n++;
        }
        d[n] = '#';
        for (j = 3; e[j] != '#'; j++)
        {
            d[n] = e[j];
            n++;
        }
        k++;
        while (d[k] != '=')
        {
            d[n] = d[k];
            n++;
            k++;
        }
        d[n] = '#';
    }
    /// <summary>
    /// 输出结果
    /// </summary>
    /// <returns></returns>
    private int result()
    {
        int f, p, j = 0;
        char x;
        d[0] = 'E';
        d[1] = '=';
        d[2] = '>';
        d[3] = 'T';
        d[4] = 'G';
        d[5] = '#';
        do
        {
            ch = UIController.grammarInputText[j];
            a[j] = ch;
            j++;
        } while (ch != '#');
        n1 = j;//n1输入串实际长度
        ch = b[0] = a[0]; //文法开始符
        grammarText.text += "步骤\t\t文法\t\t\t分析串\t\t分析字符\t\t剩余串\n";
        f = E1();
        if (f == 0)
        {
            return 0; //有语法错误，失败退出
        }
        if (ch == '#')
        { 
            grammarText.text += "accept\n";//输入串是文法的句子
            p = 0;
            x = d[p];
            while (x != '#')  //输出推导式
            {
                grammarText.text += x;
                p++;
                if (p % 40 == 0)
                {
                    grammarText.text += "\n";
                }
                x = d[p]; //输出推导式
            }
            grammarText.text += "\n";
        }
        else
        {
            grammarText.text += "error\n";
            return 0;
        }
        grammarText.text += "\n";
        return 0;
    }
    void Update()
    {
        if (UIController.isPress == true) 
        {
            UIController.isPress = false;
            print(a[0]);
            result();
            //清零
            ch = '\0';
            n1 = 0;
            i1 = 0;
            flag = 1;
            n = 5;
            total = 0;    
            for (int i = 0; i < 2000; i++)
            {
                a[i] = '\0';
                b[i] = '\0';
                d[i] = '\0';
                e[i] = '\0';
            }
        }
    }
}
