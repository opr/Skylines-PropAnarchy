﻿using System.Collections.Generic;
using System.Reflection;
using PropAnarchy.Redirection;

namespace PropAnarchy
{
    public class DetoursManager
    {
        private static Dictionary<MethodInfo, RedirectCallsState> _redirects;

        public static void Deploy()
        {
            if (IsDeployed())
            {
                return;
            }
            _redirects = RedirectionUtil.RedirectAssembly();
        }

        public static void Revert()
        {
            if (!IsDeployed())
            {
                return;
            }
            RedirectionUtil.RevertRedirects(_redirects);
            _redirects.Clear();
        }

        private static bool IsDeployed()
        {
            return _redirects != null && _redirects.Count != 0;
        }
    }
}