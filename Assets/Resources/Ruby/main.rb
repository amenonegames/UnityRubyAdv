##### メソッド定義 #####
def print(message)
    cmd :debug, message:
end

def t(message)
    cmd :talk, message:
end

def o(opMessage)
    cmd :option, options: opMessage
end

class DialogueManager
def initialize
  @nodes = {}
end

def add_node(name, &block)
  @nodes[name] = block
end

def jump(name)
  if @nodes[name]
    @nodes[name].call
  else
    puts "Node #{name} not found!"
  end
end

end
  
##### テキスト本体 #####

# ダイアログの定義
dm = DialogueManager.new

$first_time = true

dm.add_node(:start) do
    if $first_time
        print "ruby script start!"
        $first_time = false
    end
    t "Start: Please press continue button"
    dm.jump(:option)
end

dm.add_node(:option) do
    o ["Yes", "No"]
    result = state[:result].is?("Yes") #正常動作
    if result #=> true
        dm.jump(:yes_response)
    else 
        dm.jump(:no_response)
    end
end

dm.add_node(:yes_response) do
    t "Yes? Really?"
    dm.jump(:end)
end

dm.add_node(:no_response) do
    t "No? Really?"
    dm.jump(:end)
end

dm.add_node(:end) do
    t "End of the dialogue."
    t "Return to the start."
    dm.jump(:start)
end

# ダイアログの開始
dm.jump(:start)
