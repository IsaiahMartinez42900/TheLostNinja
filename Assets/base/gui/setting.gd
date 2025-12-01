extends Control


const MainMenu = preload("res://gui/main_menu.tscn")


func _ready():
	var resolution: Vector2 = $SavingSystem.get_resolution()
	if resolution == Vector2(1024, 546):
		DisplayServer.window_set_size(Vector2(1024, 546))
		$VBoxContainer/Resolution.select(0)
	elif resolution == Vector2(1280, 720):
		DisplayServer.window_set_size(Vector2(1280, 720))
		$VBoxContainer/Resolution.select(1)
	elif resolution == Vector2(1600, 900):
		DisplayServer.window_set_size(Vector2(1600, 900))
		$VBoxContainer/Resolution.select(2)
	elif resolution == Vector2(1920, 1080):
		DisplayServer.window_set_size(Vector2(1920, 1080))
		$VBoxContainer/Resolution.select(3)
	$VBoxContainer/FullScreen.button_pressed = $SavingSystem.get_full_screen()
	$VBoxContainer/Master.value = $SavingSystem.get_master()
	$VBoxContainer/Bgm.value = $SavingSystem.get_bgm()
	$VBoxContainer/Sfx.value = $SavingSystem.get_sfx()

	SoundController.add_sfx()

	$VBoxContainer/Resolution.grab_focus()


func _on_full_screen_toggled(button_pressed):
	$SavingSystem.set_full_screen(button_pressed)

	if button_pressed:
		DisplayServer.window_set_mode(3)
	else:
		DisplayServer.window_set_mode(0)


func _on_return_pressed():
	get_parent().add_child(MainMenu.instantiate())
	queue_free()


func _on_resolution_item_selected(index):
	if index == 0:
		DisplayServer.window_set_size(Vector2(1024, 546))
	elif index == 1:
		DisplayServer.window_set_size(Vector2(1280, 720))    
	elif index == 2:
		DisplayServer.window_set_size(Vector2(1600, 900))
	elif index == 3:
		DisplayServer.window_set_size(Vector2(1920, 1080))
	$SavingSystem.set_resolution(index)


func _on_master_value_changed(value):
	AudioServer.set_bus_volume_db(0, linear_to_db(value))
	$VBoxContainer/Master2.text = "Master: {value}".format({"value": value*50})
	$SavingSystem.set_master(value)


func _on_bgm_value_changed(value):
	AudioServer.set_bus_volume_db(1, linear_to_db(value))
	$VBoxContainer/Bgm2.text = "Bgm: {value}".format({"value": value*50})
	$SavingSystem.set_bgm(value)


func _on_sfx_value_changed(value):
	AudioServer.set_bus_volume_db(2, linear_to_db(value))
	$VBoxContainer/Sfx2.text = "Sfx: {value}".format({"value": value*50})
	$SavingSystem.set_sfx(value)
