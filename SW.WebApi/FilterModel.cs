// <copyright file="FilterModel.cs" company="Star Wars Inc">
// Copyright (c) Star Wars Inc. All rights reserved.
// </copyright>

namespace SW.WebAPI
{
    public class FilterModel
    {
        public FilterType Filter { get; set; }
        public string Filter1 { get; set; }
        public string Filter2 { get; set; }
        public string Filter3 { get; set; }
        public string Filter4 { get; set; }
    }
    public enum FilterType
    { 
        Name,
        Base,
        Starship,
        Qualification,
        Eqipment
    }
}
