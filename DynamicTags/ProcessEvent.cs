using DynamicTags.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicTags
{
    public static class ProcessEvent
    {
        public static bool Process(ResourceWriteSuccess evt)
        {
            switch (evt.OperationName)
            {
                case OperationType.ResourceGroupWrite:
                    /*
                     * --do what you need to do here--
                     * For example, grab properties, call into an HR system and determine a cost center for the creator's division,
                     * then use a service principal here to update the resource group tags with the value
                    */
                    
                    break;
            }
            return true;
        }
    }
}
