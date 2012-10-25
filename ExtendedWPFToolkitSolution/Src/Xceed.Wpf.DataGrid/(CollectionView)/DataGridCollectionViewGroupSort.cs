﻿/************************************************************************

   Extended WPF Toolkit

   Copyright (C) 2010-2012 Xceed Software Inc.

   This program is provided to you under the terms of the Microsoft Public
   License (Ms-PL) as published at http://wpftoolkit.codeplex.com/license 

   This program can be provided to you by Xceed Software Inc. under a
   proprietary commercial license agreement for use in non-Open Source
   projects. The commercial version of Extended WPF Toolkit also includes
   priority technical support, commercial updates, and many additional 
   useful WPF controls if you license Xceed Business Suite for WPF.

   Visit http://xceed.com and follow @datagrid on Twitter.

  **********************************************************************/

using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;

using Xceed.Utils.Collections;
using System.Collections.ObjectModel;
using Xceed.Utils.Data;

namespace Xceed.Wpf.DataGrid
{
  internal class DataGridCollectionViewGroupSort : IndexWeakHeapSort
  {
    public DataGridCollectionViewGroupSort( 
      int[] dataIndexArray,
      GroupSortComparer groupSortedComparer,
      DataGridCollectionViewGroup parentGroup )
      : base( dataIndexArray )
    {
      if( parentGroup == null )
        throw new ArgumentNullException( "parentGroup" );

      if( groupSortedComparer == null )
        throw new ArgumentNullException( "groupSortedComparer" );

      m_groupSortedComparer = groupSortedComparer;
      m_groups = parentGroup.ProtectedItems;
    }

    public override int Compare( int xDataIndex, int yDataIndex )
    {
      DataGridCollectionViewGroup xGroup = m_groups[ xDataIndex ] as DataGridCollectionViewGroup;
      DataGridCollectionViewGroup yGroup = m_groups[ yDataIndex ] as DataGridCollectionViewGroup;

      return m_groupSortedComparer.Compare( xGroup, yGroup );
    }

    private GroupSortComparer m_groupSortedComparer;
    private ObservableCollection<object> m_groups;
  }
}