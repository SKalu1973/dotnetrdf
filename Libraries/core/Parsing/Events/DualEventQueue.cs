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

#if UNFINISHED

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VDS.RDF.Parsing.Events
{
    public class DualEventQueue<T> 
        : BaseEventQueue<T> where T : IEvent
    {
        private IEventQueue<T> _queue;
        private Queue<T> _temp = new Queue<T>();

        public DualEventQueue(IEventQueue<T> queue)
        {
            this._queue = queue;
        }

        public override T Dequeue()
        {
            if (this._temp.Count > 0)
            {
                return this._temp.Dequeue();
            }
            else
            {
                return this._queue.Dequeue();
            }
        }

        public override void Enqueue(T e)
        {
            this._queue.Enqueue(e);
        }

        public void Requeue(T e)
        {
            this._temp.Enqueue(e);
        }

        public override T Peek()
        {
            if (this._temp.Count > 0)
            {
                return this._temp.Peek();
            }
            else
            {
                return this._queue.Peek();
            }
        }

        public override void Clear()
        {
            this._temp.Clear();
            this._queue.Clear();
        }

        public override int Count
        {
            get 
            {
                return this._temp.Count + this._queue.Count; 
            }
        }
    }
}

#endif