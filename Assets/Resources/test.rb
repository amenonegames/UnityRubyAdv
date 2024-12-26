def debug(message)
    cmd :debug, message:
end

def t(message)
    cmd :talk, message:
end

def o(opMessage)
    cmd :option, options: opMessage
end

debug("start")
t("please press continue button")

o(["Yes", "No"])

if state[:result].is?("Yes") #=> true
    t("Yes? Really?")
else 
    t("No? Really?")
end

t("end")