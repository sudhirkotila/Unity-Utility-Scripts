using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Simple_Sql_DB_My_Query_Demo : MonoBehaviour
{

	//=== SUDHIR_VARS ===//
	public SimpleSQL.SimpleSQLManager dbManager;
	private int unlocked_char_id;
	private string unlocked_char_name;

	// Use this for initialization
	void Start ()
	{
	
		print ("My Simple Sql Database Queries Demo");
		
		Create_UnlockedCharacterTable ();
		
//		Insert_Data_UnlockedCharacterTable ();
		
//		Display_Data_UnlockedCharacterTable ();
		
//		Delete_Data_UnlockedCharacterTable ();
		
//		Drop_UnlockedCharacterTable ();

	}


	//Create User_Table
	public void Create_UnlockedCharacterTable ()
	{
		dbManager.BeginTransaction ();
		string sql = "CREATE TABLE IF NOT EXISTS \"User_Table\" " + 
			"(\"UNLOCKED_CHAR_ID\" INTEGER, " + 
			"\"UNLOCKED_CHAR_NAME\" varchar(40))";
		
		dbManager.Execute (sql);
		dbManager.Commit ();
		dbManager.Close ();
	}
	
	//Insert Data To User_Table
	public void Insert_Data_UnlockedCharacterTable ()
	{
		unlocked_char_id = 1;
		unlocked_char_name = "sudhir";
		
		string sql = "INSERT INTO User_Table(UNLOCKED_CHAR_ID,UNLOCKED_CHAR_NAME) VALUES(?,?)";
		dbManager.Execute (sql, unlocked_char_id, unlocked_char_name);
		
		Display_Data_UnlockedCharacterTable ();
	}
	
	//Display All Records From User_Table
	public void Display_Data_UnlockedCharacterTable ()
	{
		//Display User Data		
		string sql2 = "SELECT * FROM User_Table";
		List<User_Table> usr = dbManager.Query<User_Table> (sql2);
		
		int rowCounter = 0;
		foreach (User_Table row in usr) {
			rowCounter++;
			print ("Record No : " + rowCounter + " >> Character No : " + row.UNLOCKED_CHAR_ID + " >> Character Name : " + row.UNLOCKED_CHAR_NAME);
		}
		
	}
	
	//Delete Data From User_Table
	public void Delete_Data_UnlockedCharacterTable ()
	{
		string sql;
		
		//Delete All Record From Table
		sql = "DELETE FROM User_Table";
		
		//Delete Specific Record From Table
		//		sql = "DELETE FROM User_Table WHERE UNLOCKED_CHAR_ID=5";
		
		dbManager.Execute (sql);
	}
	
	//Drop User_Table
	public void Drop_UnlockedCharacterTable ()
	{
		string sql;
		sql = "DROP TABLE \"User_Table\""; 
		dbManager.Execute (sql);
	}

}
