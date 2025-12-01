extends Control


const Hud = preload("res://gui/hud.tscn")
const Setting = preload("res://gui/setting.tscn")
const Archive = preload("res://gui/archive.tscn")
const Credit = preload("res://gui/credit.tscn")


func _ready():
	$SavingSystem.start_up_setup()
	$VBoxContainer/Play.grab_focus()
	SoundController.add_sfx()


func _on_play_pressed():
	get_parent().add_child(Hud.instantiate())
	queue_free()


func _on_setting_pressed():
	get_parent().add_child(Setting.instantiate())
	queue_free()


func _on_archive_pressed():
	get_parent().add_child(Archive.instantiate())
	queue_free()


func _on_credit_pressed():
	get_parent().add_child(Credit.instantiate())
	queue_free()


func _on_quit_pressed():
	get_tree().quit()
