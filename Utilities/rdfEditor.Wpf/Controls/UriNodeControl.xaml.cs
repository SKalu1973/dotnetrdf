/*

Copyright dotNetRDF Project 2009-12
dotnetrdf-develop@lists.sf.net

------------------------------------------------------------------------

This file is part of dotNetRDF.

dotNetRDF is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

dotNetRDF is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with dotNetRDF.  If not, see <http://www.gnu.org/licenses/>.

------------------------------------------------------------------------

dotNetRDF may alternatively be used under the LGPL or MIT License

http://www.gnu.org/licenses/lgpl.html
http://www.opensource.org/licenses/mit-license.php

If these licenses are not suitable for your intended use please contact
us at the above stated email address to discuss alternative
terms.

*/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VDS.RDF;
using VDS.RDF.Writing.Formatting;

namespace VDS.RDF.Utilities.Editor.Wpf.Controls
{
    /// <summary>
    /// Interaction logic for UriNodeControl.xaml
    /// </summary>
    public partial class UriNodeControl : UserControl
    {
        private Uri _u;

        public UriNodeControl(IUriNode u, INodeFormatter formatter)
        {
            InitializeComponent();

            this.lnkUri.Text = formatter.Format(u);
            this._u = u.Uri;
        }

        public UriNodeControl(UriNode u)
            : this(u, new NTriplesFormatter()) { }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start(this._u.AbsoluteUri);
            }
            catch
            {
                //Supress errors
            }
        }
    }
}