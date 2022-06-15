#include maps\_anim;
#include maps\_utility;
#include common_scripts\utility;
#include maps\_utility_code;

#using_animtree("generic_human");

main()
{
	if ( getdvar( "r_reflectionProbeGenerate" ) == "1" ) // Prevents Reflection Compiler from reading script.
		return;

	precacheitem("mp5");
	
	maps\_load::main(); //Beginning of every map.
	level.early_level[ level.script ] = false; // Prevents an error.

	maps\yourmapname_anim::main(); // Calls your mapname_anim.gsc file
	maps\yourmapname_fx::main(); // Calls your mapname_fx.gsc file

	thread mission_start(); // Start your mission here.

	wait 0.05; // You have to wait one frame (0.05 seconds) before calling any dvar.
	setsaveddvar( "cg_fov" , "80" ); // FOV 80 degrees.
}

mission_start()
{



}