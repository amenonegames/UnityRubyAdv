def debug(message)
    cmd :debug, message:
end

def t(message)
    cmd :talk, message:
end

def o(opMessage)
    cmd :option, options: opMessage
end

debug("Hello, World!")

t("Hello,World!")
t("continue")

o(["Yes", "No"])
