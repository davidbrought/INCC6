﻿/*
Copyright (c) 2016, Los Alamos National Security, LLC
All rights reserved.
Copyright 2016. Los Alamos National Security, LLC. This software was produced under U.S. Government contract 
DE-AC52-06NA25396 for Los Alamos National Laboratory (LANL), which is operated by Los Alamos National Security, 
LLC for the U.S. Department of Energy. The U.S. Government has rights to use, reproduce, and distribute this software.  
NEITHER THE GOVERNMENT NOR LOS ALAMOS NATIONAL SECURITY, LLC MAKES ANY WARRANTY, EXPRESS OR IMPLIED, 
OR ASSUMES ANY LIABILITY FOR THE USE OF THIS SOFTWARE.  If software is modified to produce derivative works, 
such modified software should be clearly marked, so as not to confuse it with the version available from LANL.

Additionally, redistribution and use in source and binary forms, with or without modification, are permitted provided 
that the following conditions are met:
•	Redistributions of source code must retain the above copyright notice, this list of conditions and the following 
disclaimer. 
•	Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following 
disclaimer in the documentation and/or other materials provided with the distribution. 
•	Neither the name of Los Alamos National Security, LLC, Los Alamos National Laboratory, LANL, the U.S. Government, 
nor the names of its contributors may be used to endorse or promote products derived from this software without specific 
prior written permission. 
THIS SOFTWARE IS PROVIDED BY LOS ALAMOS NATIONAL SECURITY, LLC AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED 
WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR 
PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL LOS ALAMOS NATIONAL SECURITY, LLC OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, 
INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF 
SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY 
THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING 
IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using AnalysisDefs;
using NCCReporter;
namespace NCCFile
{

    using NC = NCC.CentralizedState;

    /// <summary>
    /// Manager for INCC5 isotopic and composite isotopic input files (.iso etc)
    /// See Isotopics Data File Format p. 100, INCC Software Users Manual, March 29, 2009
    /// See Composite Isotopics Data File Format p. 101, INCC Software Users Manual, March 29, 2009
    /// </summary>
    public class IsoFiles
    {

        public IsoFiles()
        {
            Init();
        }

        public void Init()
        {
            mPathToIsoFile = new Dictionary<string, CSVFile>();
            mPathToCompFile = new Dictionary<string, CSVFile>();
            IsoIsotopics = new List<AnalysisDefs.Isotopics>();
            CompIsoIsotopics = new List<AnalysisDefs.CompositeIsotopics>();
            yyyymmdd = new Regex("^\\d{4}\\d{2}\\d{2}$");
            mlogger = NCC.CentralizedState.App.Loggers.Logger(LMLoggers.AppSection.Control);
        }
  

        /// <summary>
        /// Enum of positional column ids for the INCC5 isotopics file format
        /// </summary>
        enum IsoCol
        {
			IsoId, IsoSourceCode, Pu238, Pu239, Pu240, Pu241, Pu242, PuDate, Am241, AmDate, Pu238err, Pu239err, Pu240err, Pu241err, Pu242err, Am241err
        }

        /// <summary>
        /// Enum of positional column ids for the INCC5 composite isotopics file format
		/// CompIsoCol is the smae save for the first enum
        /// </summary>
        enum CompIsCol
        {
			IsoId, IsoSourceCode, PuMass, Pu238, Pu239, Pu240, Pu241, Pu242, PuDate, Am241, AmDate, Pu238err, Pu239err, Pu240err, Pu241err, Pu242err, Am241err
        }

		enum KindKind
        {
			Iso, CompIso, CompIsoSummary
        }

		KindKind IngestLine(List<string[]> tokens)
		{
			return 0;

		}



         /// <summary>
        /// Scan a set of iso and comp iso files.
        /// Creates a list of Isotopics from the iso files.
        /// Creates a list of CompositeIsotopics from the comp files.
        /// </summary>
        /// <param name="files">List of nop and cop files to process</param>
        public void Process(List<string> files)
        {
			if (files == null) 
				return;

            foreach (string l in files)
            try
				{
					CSVFile csv = new CSVFile();
					string name = l.Substring(l.LastIndexOf("\\") + 1); // Remove path information from string
	                csv.Log = NC.App.Loggers.Logger(LMLoggers.AppSection.Data);
	                csv.Filename = l;
		            csv.ExtractDateFromFilename();
					if (name.IndexOf('.') >= 0)
						csv.ThisSuffix = name.Substring(name.IndexOf('.'));
					csv.ProcessFile();  // split lines with scanner
					foreach (string[] entry in csv.Lines)
					{
						Isotopics iso = GenIso(entry);
						//CompositeIsotopics ciso = null;
						if (iso != null)
						{
							mlogger.TraceEvent(LogLevels.Verbose, 34100, "got an iso file, process all the lines " + System.IO.Path.GetFileName(l));
							mlogger.TraceEvent(LogLevels.Info, 34100, "Processed " + iso.id + " from " + System.IO.Path.GetFileName(csv.Filename));
							IsoIsotopics.Add(iso);
						}
						else
						{ 
							//ciso = CompositeIsotopics(entry, headtest:true);
							//if (ciso != null)  // got a header of a comp iso file, process the rest of the lines
							//{
							//	mlogger.TraceEvent(LogLevels.Verbose, 34100, "got a header of a comp iso file, process the rest of the lines " + System.IO.Path.GetFileName(l));
							//}
							//else  // a CSV file but not an iso or comp iso file
							//{
							//	//ciso = CompositeIsotopics(entry, headtest:false);
							//	mlogger.TraceEvent(LogLevels.Verbose, 34100, "Skipped " + System.IO.Path.GetFileName(l));
							//	break;
							//}
							mlogger.TraceEvent(LogLevels.Verbose, 34100, "Skipped non-ios toen entry");
						}
					}
				} 
				catch (Microsoft.VisualBasic.FileIO.MalformedLineException )  // not a CSV file
				{
					mlogger.TraceEvent(LogLevels.Verbose, 34100, "Skipped " + System.IO.Path.GetFileName(l));
				}           

        }

		Isotopics GenIso(string[] sa)
		{
			Isotopics i = new Isotopics();
			string s = string.Empty;
			double v = 0, err = 0;
			foreach (IsoCol op in System.Enum.GetValues(typeof(IsoCol)))
			{
				try
				{
					s = string.Empty;
					s = sa[(int)op];  // might blow here when file was badly created
					switch (op)
					{
					case IsoCol.AmDate:
						Match amd = yyyymmdd.Match(s);
						if (amd.Success)
							i.am_date = GenFromYYYYMMDD(s);
						break;
					case IsoCol.PuDate:
						Match pud = yyyymmdd.Match(s);
						if (pud.Success)
							i.pu_date = GenFromYYYYMMDD(s);
						break;
					case IsoCol.IsoSourceCode:
						System.Enum.TryParse<Isotopics.SourceCode>(s, out i.source_code);
						break;
					case IsoCol.IsoId:
						i.id = string.Copy(s);
						break;
					case IsoCol.Pu238:
						double.TryParse(s, out v);
						i.SetVal(Isotope.pu238, v);
						break;
					case IsoCol.Pu239:
						double.TryParse(s, out v);
						i.SetVal(Isotope.pu239, v);
						break;
					case IsoCol.Pu240:
						double.TryParse(s, out v);
						i.SetVal(Isotope.pu240, v);
						break;
					case IsoCol.Pu241:
						double.TryParse(s, out v);
						i.SetVal(Isotope.pu241, v);
						break;
					case IsoCol.Pu242:
						double.TryParse(s, out v);
						i.SetVal(Isotope.pu242, v);
						break;
					case IsoCol.Am241:
						double.TryParse(s, out v);
						i.SetVal(Isotope.am241, v);
						break;
					case IsoCol.Pu238err:
						double.TryParse(s, out err);
						i.SetError(Isotope.pu238, err);
						break;
					case IsoCol.Pu239err:
						double.TryParse(s, out err);
						i.SetError(Isotope.pu239, err);
						break;
					case IsoCol.Pu240err:
						double.TryParse(s, out err);
						i.SetError(Isotope.pu240, err);
						break;
					case IsoCol.Pu241err:
						double.TryParse(s, out err);
						i.SetError(Isotope.pu241, err);
						break;
					case IsoCol.Pu242err:
						double.TryParse(s, out err);
						i.SetError(Isotope.pu242, err);
						break;
					case IsoCol.Am241err:
						double.TryParse(s, out err);
						i.SetError(Isotope.am241, err);
						break;
					}
				} catch (Exception ex)
				{
					mlogger.TraceEvent(LogLevels.Warning, 34100, s + " fails as isotopics element " + op.ToString() + " " + ex.Message);
					return null;
				}
			}
			return i;
		}

		CompositeIsotopics CompositeIsotopics(string[] sa, bool headtest)
		{
			CompositeIsotopics i = new CompositeIsotopics();
			string s = string.Empty;
			double v = 0, err = 0;
			foreach (CompIsCol op in System.Enum.GetValues(typeof(CompIsCol)))
			{
				try
				{
					s = string.Empty;
					s = sa[(int)op];  // might blow here when file was badly created
					switch (op)
					{
					case CompIsCol.AmDate:
						Match amd = yyyymmdd.Match(s);
						if (amd.Success)
							i.am_date = GenFromYYYYMMDD(s);
						break;
					case CompIsCol.PuDate:
						Match pud = yyyymmdd.Match(s);
						if (pud.Success)
							i.pu_date = GenFromYYYYMMDD(s);
						break;
					case CompIsCol.IsoSourceCode:
						System.Enum.TryParse<CompositeIsotopics.SourceCode>(s, out i.source_code);
						break;
					case CompIsCol.IsoId:
						if (headtest) i.id = string.Copy(s);
						break;
					case CompIsCol.PuMass:
						Single sv = 0;
						Single.TryParse(s, out sv);
						i.pu_mass = sv;
						break;
					case CompIsCol.Pu238:
						double.TryParse(s, out v);
						i.SetVal(Isotope.pu238, v);
						break;
					case CompIsCol.Pu239:
						double.TryParse(s, out v);
						i.SetVal(Isotope.pu239, v);
						break;
					case CompIsCol.Pu240:
						double.TryParse(s, out v);
						i.SetVal(Isotope.pu240, v);
						break;
					case CompIsCol.Pu241:
						double.TryParse(s, out v);
						i.SetVal(Isotope.pu241, v);
						break;
					case CompIsCol.Pu242:
						double.TryParse(s, out v);
						i.SetVal(Isotope.pu242, v);
						break;
					case CompIsCol.Am241:
						double.TryParse(s, out v);
						i.SetVal(Isotope.am241, v);
						break;
					case CompIsCol.Pu238err:
						double.TryParse(s, out err);
						i.SetError(Isotope.pu238, err);
						break;
					case CompIsCol.Pu239err:
						double.TryParse(s, out err);
						i.SetError(Isotope.pu239, err);
						break;
					case CompIsCol.Pu240err:
						double.TryParse(s, out err);
						i.SetError(Isotope.pu240, err);
						break;
					case CompIsCol.Pu241err:
						double.TryParse(s, out err);
						i.SetError(Isotope.pu241, err);
						break;
					case CompIsCol.Pu242err:
						double.TryParse(s, out err);
						i.SetError(Isotope.pu242, err);
						break;
					case CompIsCol.Am241err:
						double.TryParse(s, out err);
						i.SetVal(Isotope.am241, err);
						break;
					}
				} catch (Exception ex)
				{
					mlogger.TraceEvent(LogLevels.Warning, 34100, s + " fails as composite isotopics summary element " + op.ToString() + " " + ex.Message);
					return null;
				}
			}
			return i;
		}


		CompositeIsotopics GenCompIso(string[] sa)
		{
			CompositeIsotopics i = new CompositeIsotopics();
			string s = string.Empty;
			double v = 0, err = 0;
			foreach (CompIsCol op in System.Enum.GetValues(typeof(CompIsCol)))
			{
				try
				{
					s = string.Empty;
					s = sa[(int)op];  // might blow here when file was badly created
					switch (op)
					{
						case CompIsCol.IsoId:  // skip this for body lines						
						break;
					case CompIsCol.AmDate:
						Match amd = yyyymmdd.Match(s);
						if (amd.Success)
							i.am_date = GenFromYYYYMMDD(s);
						break;
					case CompIsCol.PuDate:
						Match pud = yyyymmdd.Match(s);
						if (pud.Success)
							i.pu_date = GenFromYYYYMMDD(s);
						break;
					case CompIsCol.IsoSourceCode:
						System.Enum.TryParse<CompositeIsotopics.SourceCode>(s, out i.source_code);
						break;
					case CompIsCol.PuMass:
						Single sv = 0;
						Single.TryParse(s, out sv);
						i.pu_mass = sv;
						break;
					case CompIsCol.Pu238:
						double.TryParse(s, out v);
						i.SetVal(Isotope.pu238, v);
						break;
					case CompIsCol.Pu239:
						double.TryParse(s, out v);
						i.SetVal(Isotope.pu239, v);
						break;
					case CompIsCol.Pu240:
						double.TryParse(s, out v);
						i.SetVal(Isotope.pu240, v);
						break;
					case CompIsCol.Pu241:
						double.TryParse(s, out v);
						i.SetVal(Isotope.pu241, v);
						break;
					case CompIsCol.Pu242:
						double.TryParse(s, out v);
						i.SetVal(Isotope.pu242, v);
						break;
					case CompIsCol.Am241:
						double.TryParse(s, out v);
						i.SetVal(Isotope.am241, v);
						break;
					case CompIsCol.Pu238err:
						double.TryParse(s, out err);
						i.SetError(Isotope.pu238, err);
						break;
					case CompIsCol.Pu239err:
						double.TryParse(s, out err);
						i.SetError(Isotope.pu239, err);
						break;
					case CompIsCol.Pu240err:
						double.TryParse(s, out err);
						i.SetError(Isotope.pu240, err);
						break;
					case CompIsCol.Pu241err:
						double.TryParse(s, out err);
						i.SetError(Isotope.pu241, err);
						break;
					case CompIsCol.Pu242err:
						double.TryParse(s, out err);
						i.SetError(Isotope.pu242, err);
						break;
					case CompIsCol.Am241err:
						double.TryParse(s, out err);
						i.SetVal(Isotope.am241, err);
						break;
					}
				} catch (Exception ex)
				{
					mlogger.TraceEvent(LogLevels.Warning, 34100, s + " fails as composite isotopics summary element " + op.ToString() + " " + ex.Message);
					return null;
				}
			}
			return i;
		}


		// The results of processing a folder with nop and cop files
		public List<Isotopics> IsoIsotopics;
        public List<CompositeIsotopics> CompIsoIsotopics;

        // private vars used for processing
        private Dictionary<string, CSVFile> mPathToIsoFile;
        private Dictionary<string, CSVFile> mPathToCompFile;
        private Regex yyyymmdd;
        private LMLoggers.LognLM mlogger;


        /// <summary>
        /// Scan YYYYMMDD string and generate DateTime object from it.
        /// Assumes string is at least 6 chars long and string was vetted by caller
        /// </summary>
        /// <param name="s">The yyyymmdd</param>
        /// <returns>The equivalent DateTime instance</returns>
        static DateTime GenFromYYYYMMDD(string s)
        {
            int y, m, d;
            int.TryParse(s.Substring(0, 4), out y);
            int.TryParse(s.Substring(4, 2), out m);
            int.TryParse(s.Substring(6, 2), out d);
            DateTime dt = new DateTime(y, m, d);
            return dt;
        }



        protected void IsotopicGen()
        {
            // for each isotopics found, either overwrite existing isotopics, or add them to the list
            // write all the changes to the DB

            List<AnalysisDefs.Isotopics> l = NC.App.DB.Isotopics.GetList();

            foreach (Isotopics isotopics in IsoIsotopics)
            {
                // if sum of Pu isotopes <= 0 then use default isotopics vals
                if ((isotopics.pu238 + isotopics.pu239 + isotopics.pu240 + isotopics.pu241 + isotopics.pu242) <= 0.0)
                    isotopics.InitVals();

                Isotopics ex = l.Find(iso => string.Compare(iso.id, isotopics.id, true) == 0);
                if (ex == null)
                {
                    l.Add(isotopics); isotopics.modified = true;
                    NC.App.DB.Isotopics.Set(isotopics);
                }
                else
                {
                    ex.Copy(isotopics); ex.modified = true;
                    NC.App.DB.Isotopics.Set(ex);
                }
            }


        }


    }

}
