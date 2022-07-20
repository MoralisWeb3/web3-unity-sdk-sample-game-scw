using System;
using UnityEngine;

namespace MoralisUnity.Samples.Shared.Attributes
{
    //MAYBE: Replace this concept with something like 'filename' for use in Resources.Load()?
    //Which one is more brittle? Guid or filename? Maybe guid is indeed best and keep as is.
    [AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
    public class InspectorCommentAttribute : PropertyAttribute
    {
        public readonly string Comment;
     
        public InspectorCommentAttribute( string comment) {
            Comment = comment;
        }
    }
}
