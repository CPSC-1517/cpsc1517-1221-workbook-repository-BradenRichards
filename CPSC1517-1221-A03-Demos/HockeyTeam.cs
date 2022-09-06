using System;

public class HockeyTeam
{
	public HockeyTeam()
	{
		public enum NHLConference { Eastern, Western };

		public enum NHLDivision { Pacific, Atlantic, Central, Metropolitan };

	//Define data fields for storing data
	private NHLConference _conference;
	private NHLDivision _division;

	//Define fully-implemented properties for the data fields
	public NHLConference Conference
	{
		get { return _conference; }
	}

	public NHLDivision Division
	{
		get { return _division; }
	}

	}
}
