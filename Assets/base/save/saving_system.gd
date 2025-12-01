extends Node


const SAVE_PATH = "user://save.cfg"


var config = ConfigFile.new()
var load_response = config.load(SAVE_PATH)


func start_up_setup():
	DisplayServer.window_set_size(get_resolution())
	
	if get_full_screen():
		DisplayServer.window_set_mode(3)
	else:
		DisplayServer.window_set_mode(0)
	
	AudioServer.set_bus_volume_db(0, linear_to_db(get_master()))
	AudioServer.set_bus_volume_db(1, linear_to_db(get_bgm()))
	AudioServer.set_bus_volume_db(2, linear_to_db(get_sfx()))


func set_first_time(first_time):
	config.set_value("section", "first_time", first_time)
	config.save(SAVE_PATH)


func get_first_time():
	return config.get_value("section", "first_time", true)


func set_resolution(resolution):
	config.set_value("setting", "resolution", resolution)
	config.save(SAVE_PATH)


func get_resolution():
	var i: int = config.get_value("setting", "resolution", 1)
	if i == 0:
		DisplayServer.window_set_size(Vector2(1024, 546))
		return Vector2(1024, 546)
	elif i == 1:
		DisplayServer.window_set_size(Vector2(1280, 720))
		return Vector2(1280, 720)
	elif i == 2:
		DisplayServer.window_set_size(Vector2(1600, 900))
		return Vector2(1600, 900)
	elif i == 3:
		DisplayServer.window_set_size(Vector2(1920, 1080))
		return Vector2(1920, 1080)


func set_full_screen(full_screen):
	config.set_value("setting", "full_screen", full_screen)
	config.save(SAVE_PATH)


func get_full_screen():
	return config.get_value("setting", "full_screen", true)


func set_master(volume):
	config.set_value("setting", "master", volume)
	config.save(SAVE_PATH)


func get_master():
	return config.get_value("setting", "master", 1)


func set_bgm(volume):
	config.set_value("setting", "bgm", volume)
	config.save(SAVE_PATH)


func get_bgm():
	return config.get_value("setting", "bgm", 1)


func set_sfx(volume):
	config.set_value("setting", "sfx", volume)
	config.save(SAVE_PATH)


func get_sfx():
	return config.get_value("setting", "sfx", 1)
