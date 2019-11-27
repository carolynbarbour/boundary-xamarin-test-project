using System;
using Android.App;
using Android.Runtime;
using code_test.common;
using MvvmCross.Droid.Support.V7.AppCompat;

namespace code_test.Droid
{
    [Application]
    public class MainApplication : MvxAppCompatApplication<Setup, CodeTestApp>
    {
        public MainApplication() : base()
        {
        }
        
        public MainApplication(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }
    }
}