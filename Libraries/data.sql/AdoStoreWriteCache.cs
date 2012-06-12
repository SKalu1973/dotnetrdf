﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using VDS.Common;

namespace VDS.RDF.Storage
{
    [Obsolete("The Data.Sql Library is being deprecated in favour of the many open source and commercial triple stores supported by the core library which are far more performant.  Please switch over your code to an alternative triple store, we will no longer support/distribute this library after the 0.7.x series of releases", false)]
    class AdoStoreWriteCache
    {
        private HashTable<int, AdoStoreNodeID> _cache = new HashTable<int, AdoStoreNodeID>(1);

        public AdoStoreNodeID GetNodeID(INode n)
        {
            AdoStoreNodeID id = new AdoStoreNodeID(n);
            if (this._cache.TryGetValue(n.GetHashCode(), out id))
            {
                return id;
            }
            else
            {
                return new AdoStoreNodeID(n);
            }
        }

        public void AddNodeID(AdoStoreNodeID id)
        {
            this._cache.Add(id.Node.GetHashCode(), id);
        }
    }

    [Obsolete("The Data.Sql Library is being deprecated in favour of the many open source and commercial triple stores supported by the core library which are far more performant.  Please switch over your code to an alternative triple store, we will no longer support/distribute this library after the 0.7.x series of releases", false)]
    class AdoStoreNodeID
    {
        private INode _n;
        private int _id = 0;

        public AdoStoreNodeID(INode n)
            : this(n, 0) { }

        public AdoStoreNodeID(INode n, int id)
        {
            this._n = n;
            this._id = id;
        }

        public INode Node
        {
            get
            {
                return this._n;
            }
        }

        public int ID
        {
            get
            {
                return this._id;
            }
            set
            {
                if (this._id <= 0)
                {
                    this._id = value;
                }
                else
                {
                    throw new InvalidOperationException("Cannot change the ID once it has been set");
                }
            }
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            if (obj is AdoStoreNodeID)
            {
                return this._n.Equals(((AdoStoreNodeID)obj).Node);
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return this._n.GetHashCode();
        }
    }
}
