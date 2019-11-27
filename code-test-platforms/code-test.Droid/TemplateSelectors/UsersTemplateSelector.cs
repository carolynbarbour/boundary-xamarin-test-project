using System;
using System.Collections.Generic;
using code_test.common.Models;
using MvvmCross.Droid.Support.V7.RecyclerView.ItemTemplates;

namespace code_test.Droid.TemplateSelectors
{
    public class UsersTemplateSelector : IMvxTemplateSelector
    {
        private readonly Dictionary<Type, int> _typeDictionary = new Dictionary<Type, int>
        {
            [typeof(User)] = Resource.Layout.item_name
        };
        
        public int GetItemViewType(object forItemObject)
        {
            return _typeDictionary[forItemObject.GetType()];
        }

        public int GetItemLayoutId(int fromViewType)
        {
            return fromViewType;
        }

        public int ItemTemplateId { get; set; }
    }
}