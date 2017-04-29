using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;
using System . Threading . Tasks;

namespace Koshi_giu
{
    interface Method
    {
        double [ ] X { get;  set; }
        double [ ] [ ] U { get;  set; }

        double [ ] Solve ( Func<double , double [ ] , double> [ ] right_funcs , double [ ][] u0 , double x0 , double x , int n );
        //double Initialise ( double [ ] u0 , double x0 , double x , int n );
        //double [ ] [ ] Form_u ( double [ ][ ] u0  );
        //void Calculate_u ( Func<double , double [ ] , double> [ ] right_funcs , double h , int current_i );
    }
}
