extends Node


const MainMenu = preload("res://gui/main_menu.tscn")


func _ready():
	$GUI.add_child(MainMenu.instantiate())
	
	SoundController.play_music("frozen_winter")
