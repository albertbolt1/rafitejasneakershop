//  ---------------------------------------------------------------------------------
//  Copyright (c) Microsoft Corporation.  All rights reserved.
// 
//  The MIT License (MIT)
// 
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
// 
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
// 
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
//  ---------------------------------------------------------------------------------

using System;

namespace YetAnotherShoppingApp
{
    /// <summary>
    /// The "database" that stores our list of products.
    /// </summary>
    static class ProductDatabase
    {
        /// <summary>
        /// A list of all the products that are avaliable for sale.
        /// </summary>
        public static readonly Product[] ProductList = new Product[]
        {
            new Product("/Assets/Jordan.jpg", "Jordan 1 RED BLACK", "Red and black classic collection", 80.00m),
            new Product("/Assets/Jordan2.jpg", "Jordan 2 BLACK", "Black and grey total comfort", 100.50m),
            new Product("/Assets/Jordan3.jpg", "Jordan 3 BLACK GREY", "black and grey print , crazy!!", 100.00m),
            new Product("/Assets/Jordan4.jpg", "Jordan 4 RED WHITE", "crazy colorway , Special edition", 110.00m),
            new Product("/Assets/Jordan5.jpg", "JORDAN 5 WHITE BLUE", "A depressing frown that brings you back down to reality.", 70.00m),
            new Product("/Assets/Jordan6.jpg", "JORDAN 6 RED WHITE", "Will fix everything.", 90.00m)
        };
    }
}
