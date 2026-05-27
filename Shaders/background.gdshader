shader_type canvas_item;

uniform float SPEED;

void vertex() {
	UV.y -= TIME * SPEED;
}
