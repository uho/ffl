\ ==============================================================================
\
\     rgx_test - the test words for the rgx,nfe and nfs module in the ffl
\
\               Copyright (C) 2007  Dick van Oudheusden
\  
\ This library is free software; you can redistribute it and/or
\ modify it under the terms of the GNU General Public
\ License as published by the Free Software Foundation; either
\ version 2 of the License, or (at your option) any later version.
\
\ This library is distributed in the hope that it will be useful,
\ but WITHOUT ANY WARRANTY; without even the implied warranty of
\ MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
\ General Public License for more details.
\
\ You should have received a copy of the GNU General Public
\ License along with this library; if not, write to the Free
\ Software Foundation, Inc., 675 Mass Ave, Cambridge, MA 02139, USA.
\
\ ==============================================================================
\ 
\  $Date: 2007-05-28 06:46:13 $ $Revision: 1.2 $
\
\ ==============================================================================

include ffl/rgx.fs
include ffl/tst.fs


.( Testing: rgx, nfe and nfs) cr 

t{ rgx-create rgx1 }t

\ Pattern scanner errors

t{ s" a(" rgx1 rgx-compile ?false 1 ?s }t \ ToDo 
\ t{ s" a)" rgx1 rgx-compile ?false . }t \ ToDo
t{ s" ()" rgx1 rgx-compile ?false 1 ?s }t \ ToDo
t{ s" a|" rgx1 rgx-compile ?false 2 ?s }t \ ToDo
t{ s" |a" rgx1 rgx-compile ?false 0 ?s }t \ ToDo
t{ s" *"  rgx1 rgx-compile ?false 0 ?s }t \ ToDo

\ Correct patterns

t{ s" ((a)(b))" rgx1 rgx-compile ?true }t

t{ s" ab" false rgx1 nfe-match ?true }t

t{ 0 rgx1 nfe-match@ 0 ?s 2 ?s }t
t{ 1 rgx1 nfe-match@ 0 ?s 2 ?s }t
t{ 2 rgx1 nfe-match@ 0 ?s 1 ?s }t
t{ 3 rgx1 nfe-match@ 1 ?s 2 ?s }t


t{ s" (a)*" rgx1 rgx-compile ?true }t

t{ s" aa" false rgx1 nfe-match ?true }t

t{ 0 rgx1 nfe-match@ 0 ?s 2 ?s }t
t{ 1 rgx1 nfe-match@ 1 ?s 2 ?s }t



t{ s" (a)*b" rgx1 rgx-compile ?true }t

t{ s" b" false rgx1 nfe-match ?true }t

t{ 0 rgx1 nfe-match@  0 ?s  1 ?s }t
t{ 1 rgx1 nfe-match@ -1 ?s -1 ?s }t



t{ s" (a*)b" rgx1 rgx-compile ?true }t

t{ s" b" false rgx1 nfe-match ?true }t

t{ 0 rgx1 nfe-match@  0 ?s  1 ?s }t
t{ 1 rgx1 nfe-match@  0 ?s  0 ?s }t



t{ s" ((a*)b)*" rgx1 rgx-compile ?true }t

t{ s" abb" false rgx1 nfe-match ?true }t

t{ 0 rgx1 nfe-match@  0 ?s  3 ?s }t
t{ 1 rgx1 nfe-match@  2 ?s  3 ?s }t
t{ 2 rgx1 nfe-match@  2 ?s  2 ?s }t



t{ s" ((a)*b)*" rgx1 rgx-compile ?true }t

t{ s" abb" false rgx1 nfe-match ?true }t

t{ 0 rgx1 nfe-match@  0 ?s  3 ?s }t
t{ 1 rgx1 nfe-match@  2 ?s  3 ?s }t
t{ 2 rgx1 nfe-match@  0 ?s  1 ?s }t



t{ s" ((a)*b)*c" rgx1 rgx-compile ?true }t

t{ s" c" false rgx1 nfe-match ?true }t

t{ 0 rgx1 nfe-match@   0 ?s   1 ?s }t
t{ 1 rgx1 nfe-match@  -1 ?s  -1 ?s }t
t{ 2 rgx1 nfe-match@  -1 ?s  -1 ?s }t


t{ s" (a*)+" rgx1 rgx-compile ?true }t

t{ s" aaa" false rgx1 nfe-match ?true }t

t{ 0 rgx1 nfe-match@ 0 ?s 3 ?s }t
t{ 1 rgx1 nfe-match@ 0 ?s 3 ?s }t




t{ s" (a|aa)(a|aa)" rgx1 rgx-compile ?true }t

t{ s" aaa" false rgx1 nfe-match ?true }t

t{ 0 rgx1 nfe-match@ 0 ?s 3 ?s }t \ ToDo: is this okee ?
t{ 1 rgx1 nfe-match@ 0 ?s 2 ?s }t
t{ 2 rgx1 nfe-match@ 2 ?s 3 ?s }t

[THEN]

\ ==============================================================================
