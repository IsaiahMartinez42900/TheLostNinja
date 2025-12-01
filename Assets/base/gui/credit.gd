extends Control


const MainMenu = preload("res://gui/main_menu.tscn")


func _ready():
	$VBoxContainer/Return.grab_focus()
	
	SoundController.add_sfx()


func _on_return_pressed():
	get_parent().add_child(MainMenu.instantiate())
	queue_free()
