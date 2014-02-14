/*
* Copyright (c) 2012 The Broad Institute
* 
* Permission is hereby granted, free of charge, to any person
* obtaining a copy of this software and associated documentation
* files (the "Software"), to deal in the Software without
* restriction, including without limitation the rights to use,
* copy, modify, merge, publish, distribute, sublicense, and/or sell
* copies of the Software, and to permit persons to whom the
* Software is furnished to do so, subject to the following
* conditions:
* 
* The above copyright notice and this permission notice shall be
* included in all copies or substantial portions of the Software.
* 
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
* EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
* OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
* NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
* HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
* WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
* FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR
* THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

namespace Bio.VCF
{


	/// <summary>
	/// @author ebanks
	///         <p/>
	///         Class VCFFormatHeaderLine
	///         <p/>
	///         A class representing a key=value entry for genotype FORMAT fields in the VCF header
	/// </summary>
	public class VCFFormatHeaderLine : VCFCompoundHeaderLine
	{

		public VCFFormatHeaderLine(string name, int count, VCFHeaderLineType type, string description)
            : base(name, count, type, description, SupportedHeaderLineType.FORMAT)
		{
			if (type == VCFHeaderLineType.Flag)
			{
				throw new System.ArgumentException("Flag is an unsupported type for format fields");
			}
		}

		public VCFFormatHeaderLine(string name, VCFHeaderLineCount count, VCFHeaderLineType type, string description) 
            : base(name, count, type, description, SupportedHeaderLineType.FORMAT)
		{
		}

		public VCFFormatHeaderLine(string line, VCFHeaderVersion version)
            : base(line, version, SupportedHeaderLineType.FORMAT)
		{
		}

		// format fields do not allow flag values (that wouldn't make much sense, how would you encode this in the genotype).
		internal override bool allowFlagValues()
		{
			return false;
		}
	}
}