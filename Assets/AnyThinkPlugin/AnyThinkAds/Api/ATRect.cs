using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnyThinkAds.Api
{
    public class ATRect
    {
        public ATRect(int x, int y, int width, int height, bool usesPixel)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.usesPixel = usesPixel;
        }

        public ATRect(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public int x = 0;
        public int y = 0;
        public int width = 0;
        public int height = 0;
        // public bool usesPixel = false;
        #if UNITY_ANDROID
            public bool usesPixel = true;
        #else 
            public bool usesPixel = false;
        #endif
    }

    public class ATSize
    {
        public ATSize(int width, int height, bool usesPixel)
        {
            this.width = width;
            this.height = height;
            this.usesPixel = usesPixel;
        }

        public ATSize(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public int width = 0;
        public int height = 0;

        #if UNITY_ANDROID
            public bool usesPixel = true;
        #else 
            public bool usesPixel = false;
        #endif
    }
}
