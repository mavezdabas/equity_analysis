//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace DataAccessLayer
{
    public partial class User
    {
        #region Primitive Properties
    
        public virtual int UserID
        {
            get;
            set;
        }
    
        public virtual string UserName
        {
            get;
            set;
        }
    
        public virtual string Name
        {
            get;
            set;
        }
    
        public virtual int RoleID
        {
            get { return _roleID; }
            set
            {
                if (_roleID != value)
                {
                    if (UserRole != null && UserRole.RoleID != value)
                    {
                        UserRole = null;
                    }
                    _roleID = value;
                }
            }
        }
        private int _roleID;
    
        public virtual string Password
        {
            get;
            set;
        }
    
        public virtual System.DateTime DOB
        {
            get;
            set;
        }

        #endregion
        #region Navigation Properties
    
        public virtual ICollection<Order> Orders
        {
            get
            {
                if (_orders == null)
                {
                    var newCollection = new FixupCollection<Order>();
                    newCollection.CollectionChanged += FixupOrders;
                    _orders = newCollection;
                }
                return _orders;
            }
            set
            {
                if (!ReferenceEquals(_orders, value))
                {
                    var previousValue = _orders as FixupCollection<Order>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupOrders;
                    }
                    _orders = value;
                    var newValue = value as FixupCollection<Order>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupOrders;
                    }
                }
            }
        }
        private ICollection<Order> _orders;
    
        public virtual ICollection<Order> Orders1
        {
            get
            {
                if (_orders1 == null)
                {
                    var newCollection = new FixupCollection<Order>();
                    newCollection.CollectionChanged += FixupOrders1;
                    _orders1 = newCollection;
                }
                return _orders1;
            }
            set
            {
                if (!ReferenceEquals(_orders1, value))
                {
                    var previousValue = _orders1 as FixupCollection<Order>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= FixupOrders1;
                    }
                    _orders1 = value;
                    var newValue = value as FixupCollection<Order>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += FixupOrders1;
                    }
                }
            }
        }
        private ICollection<Order> _orders1;
    
        public virtual UserRole UserRole
        {
            get { return _userRole; }
            set
            {
                if (!ReferenceEquals(_userRole, value))
                {
                    var previousValue = _userRole;
                    _userRole = value;
                    FixupUserRole(previousValue);
                }
            }
        }
        private UserRole _userRole;

        #endregion
        #region Association Fixup
    
        private void FixupUserRole(UserRole previousValue)
        {
            if (previousValue != null && previousValue.Users.Contains(this))
            {
                previousValue.Users.Remove(this);
            }
    
            if (UserRole != null)
            {
                if (!UserRole.Users.Contains(this))
                {
                    UserRole.Users.Add(this);
                }
                if (RoleID != UserRole.RoleID)
                {
                    RoleID = UserRole.RoleID;
                }
            }
        }
    
        private void FixupOrders(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Order item in e.NewItems)
                {
                    item.User = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Order item in e.OldItems)
                {
                    if (ReferenceEquals(item.User, this))
                    {
                        item.User = null;
                    }
                }
            }
        }
    
        private void FixupOrders1(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Order item in e.NewItems)
                {
                    item.User1 = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (Order item in e.OldItems)
                {
                    if (ReferenceEquals(item.User1, this))
                    {
                        item.User1 = null;
                    }
                }
            }
        }

        #endregion
    }
}