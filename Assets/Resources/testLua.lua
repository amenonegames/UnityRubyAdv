local t = function( message )
    talk( message )
end

local o = function( options )
    return option( options )
end

print "Hello Lua" 

t "Please Press Continue" 

local result = o { "Yes", "No" }

if result == "Yes" then
    t "You Pressed Yes" 
else
    t "You Pressed No" 
end

t "end" 