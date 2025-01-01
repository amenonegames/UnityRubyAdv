
local helpers = require ("Assets/Resources/commands.lua")
local dm = require ("Assets/Resources/DialogueManager.lua")

local t = helpers.t
local o = helpers.o

local addNode = function(...) dm:addNode(...) end
local jump = function(...) dm:jump(...) end

addNode ("start", function()
    t "Hello, World!"
    t "This is a test."
    t "Please Press Continue"
    jump ("continue")
end)

addNode ("continue", function()
    t "Do you want to continue?"
    local result = o { "Yes", "No" }
    if result == "Yes" then
        jump ("yesResponse")
    else
        jump ("noResponse")
    end
end)

addNode ("yesResponse", function()
    t "You chose Yes!"
    t "Goodbye!"
    t "end"
end)

addNode ("noResponse", function()
    t "You chose No!"
    t "Goodbye!"
    t "end"
end)

dm:start()
