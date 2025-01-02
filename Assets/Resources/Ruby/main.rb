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
  @state = state
end

def add_node(name, &block)
  @nodes[name] = block
end

def jump_to(name)
  if @nodes[name]
    @nodes[name].call
  else
    puts "Node #{name} not found!"
  end
end

end
  
##### テキスト本体 #####

# ダイアログの定義
manager = DialogueManager.new

$first_time = true

manager.add_node(:start) do
    if $first_time
        print "ruby script start!"
        $first_time = false
    end
    t "Start: Please press continue button"
    manager.jump_to(:option)
end

manager.add_node(:option) do
    o ["Yes", "No"]
    result = state[:result].is?("Yes") #正常動作
    if result #=> true
        manager.jump_to(:yes_response)
    else 
        manager.jump_to(:no_response)
    end
end

manager.add_node(:yes_response) do
    t "Yes? Really?"
    manager.jump_to(:end)
end

manager.add_node(:no_response) do
    t "No? Really?"
    manager.jump_to(:end)
end

manager.add_node(:end) do
    t "End of the dialogue."
    t "Return to the start."
    manager.jump_to(:start)
end

# ダイアログの開始
manager.jump_to(:start)
