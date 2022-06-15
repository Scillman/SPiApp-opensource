#include maps\_anim;
#include maps\_utility;
#include maps\_utility_code;
#include common_scripts\utility;
#using_animtree("generic_human");

main()
{
    if ( getDvar( "r_reflectionProbeGenerate" ) == "1" )
        return;
    
    maps\_load::main();
    level.early_level[ level.script ] = false;
    
    maps\yourmapname_anim::main();
    maps\yourmapname_fx::main();
    maps\yourmapname_amb::main();
    
    thread start();
}

start()
{
    // Do actual mission related stuff from this point onwards.
}
