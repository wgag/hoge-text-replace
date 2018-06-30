## About this Project

This project is a Hoge-Text-Replacer-specific modification of Azuki 1.7.13.

The original project is developed by Suguru YAMAMOTO,
and is distributed under the zlib/libpng License.

Azuki project page:
http://sourceforge.jp/projects/azuki

## Modifications

```diff  
--- a/Azuki-1.7.13/View/View.Paint.cs   2016-08-27 21:51:24.000000000 +0900
+++ b/Azuki-1.7.13/View/View.Paint.cs   2018-06-30 23:02:35.252480000 +0900
@@ -143,8 +143,11 @@

                  // before to draw background,
                  // change bgcolor to normal if it's not selected
-                 if( inSelection == false )
-                     g.BackColor = ColorScheme.BackColor;
+
+                 // MODIFICATION FOR HOGE TEXT REPLACE:
+                 // The following two lines commented out to highlight EOL marks
+                 // if ( inSelection == false )
+                 //     g.BackColor = ColorScheme.BackColor;

                  // draw background
                  width = EolCodeWidthInPx;
```
