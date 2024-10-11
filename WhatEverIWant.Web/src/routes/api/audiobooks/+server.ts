import type { RequestHandler } from '@sveltejs/kit';

interface Audiobook {
	id: number;
	name: string;
	author: string;
	narrator: string;
	duration: string;
	genre: string;
	releaseDate: string;
	description: string;
}

export const GET: RequestHandler = async () => {
	const audiobooks: Audiobook[] = [
		{
			id: 1,
			name: 'Alien',
			author: 'Alan Dean Foster',
			narrator: 'Peter Guinness',
			duration: '8h 50m',
			genre: 'Science Fiction',
			releaseDate: '1979-05-25',
			description:
				'After a space merchant vessel receives an unknown transmission as a distress call, one of the crew is attacked by a mysterious life form and they soon realize that its life cycle has merely begun.'
		}
		// Add more mock audiobooks as needed
	];

	return new Response(JSON.stringify(audiobooks), {
		status: 200,
		headers: {
			'Content-Type': 'application/json'
		}
	});
};
